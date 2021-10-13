----- Finding duplicate values in a table with a unique index
--Solution 1
SELECT a.* 
FROM TableA a, (SELECT ID, (SELECT MAX(Value) FROM TableA i WHERE o.Value=i.Value GROUP BY Value HAVING o.ID < MAX(i.ID)) AS MaxValue FROM TableA o) b
WHERE a.ID=b.ID AND b.MaxValue IS NOT NULL

--Solution 2
SELECT a.* 
FROM TableA a, (SELECT ID, (SELECT MAX(Value) FROM TableA i WHERE o.Value=i.Value GROUP BY Value HAVING o.ID=MAX(i.ID)) AS MaxValue FROM TableA o) b
WHERE a.ID=b.ID AND b.MaxValue IS NULL

--Solution 3
SELECT a.*
FROM TableA a
INNER JOIN
(
 SELECT MAX(ID) AS ID, Value 
 FROM TableA
 GROUP BY Value 
 HAVING COUNT(Value) > 1
) b
ON a.ID < b.ID AND a.Value=b.Value

--Solution 4
SELECT a.* 
FROM TableA a 
WHERE ID < (SELECT MAX(ID) FROM TableA b WHERE a.Value=b.Value GROUP BY Value HAVING COUNT(*) > 1)

--Solution 5 
SELECT a.*
FROM TableA a
INNER JOIN
(SELECT ID, RANK() OVER(PARTITION BY Value ORDER BY ID DESC) AS rnk FROM TableA ) b 
ON a.ID=b.ID
WHERE b.rnk > 1

--Solution 6 
SELECT * 
FROM TableA 
WHERE ID NOT IN (SELECT MAX(ID) 
                 FROM TableA 
                 GROUP BY Value)

/*
Question - Suppose number of columns are not fixed?
How do you design database for this kind of system?
-One way is to create a single column VARCHAR(MAX) with a
separator. It works like below
*/
CREATE TABLE TestMulCols
(
 Data VARCHAR(MAX)
)
GO
INSERT INTO TestMulCols VALUES('a,b,c,d,e')
INSERT INTO TestMulCols VALUES('r,e')
INSERT INTO TestMulCols VALUES('d,q,j,k,o,i,i,i,i,2')
;WITH CTE AS
(
 SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) Rnk, Data
FROM TestMulCols
)
,CTE1 AS
(
 SELECT tr.ID , tr.VALUE, CTE.Rnk FROM CTE
 CROSS APPLY (SELECT ID,Value from STRING_SPLIT(Data,','))
tr
)
SELECT * FROM CTE1
PIVOT
(MAX([Value]) FOR ID In
([1],[2],[3],[4],[5],[6],[7],[8],[9],[10])) p
/*
Output
Rnk 1 2 3 4 5 6 7 8 9 10
1 a b c d e NULL NULL NULL NULL NULL
2 r e NULL NULL NULL NULL NULL NULL NULL NULL
3 d q j k o i i i i 2
*/

/*recursive cte to display employee hierarchy level*/
CREATE TABLE Employees
(
  EmployeeID int NOT NULL PRIMARY KEY,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  ManagerID int NULL
)

INSERT INTO Employees VALUES (1, 'Ken', 'Thompson', NULL)
INSERT INTO Employees VALUES (2, 'Terri', 'Ryan', 1)
INSERT INTO Employees VALUES (3, 'Robert', 'Durello', 1)
INSERT INTO Employees VALUES (4, 'Rob', 'Bailey', 2)
INSERT INTO Employees VALUES (5, 'Kent', 'Erickson', 2)
INSERT INTO Employees VALUES (6, 'Bill', 'Goldberg', 3)
INSERT INTO Employees VALUES (7, 'Ryan', 'Miller', 3)
INSERT INTO Employees VALUES (8, 'Dane', 'Mark', 5)
INSERT INTO Employees VALUES (9, 'Charles', 'Matthew', 6)
INSERT INTO Employees VALUES (10, 'Michael', 'Jhonson', 6);

WITH cteReports (EmpID, FirstName, LastName, MgrID, EmpLevel)
  AS
  (
    SELECT EmployeeID, FirstName, LastName, ManagerID, 1
    FROM Employees
    WHERE ManagerID IS NULL
    UNION ALL
    SELECT e.EmployeeID, e.FirstName, e.LastName, e.ManagerID, 
      r.EmpLevel + 1
    FROM Employees e
      INNER JOIN cteReports r
        ON e.ManagerID = r.EmpID
  )
SELECT
  FirstName + ' ' + LastName AS FullName, 
  EmpLevel,
  (SELECT FirstName + ' ' + LastName FROM Employees 
    WHERE EmployeeID = cteReports.MgrID) AS Manager
FROM cteReports 
ORDER BY EmpLevel, MgrID