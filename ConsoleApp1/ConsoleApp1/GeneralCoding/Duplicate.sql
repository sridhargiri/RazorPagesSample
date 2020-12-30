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
