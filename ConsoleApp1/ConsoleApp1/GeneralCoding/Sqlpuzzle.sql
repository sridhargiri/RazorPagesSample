--bus passenger problem
/*Refer AuthorityPartners.cs*/
create table buses(
id int primary key,
origin varchar(10) not null,
destination varchar(10) not null,
[time] varchar(10) not null)
CREATE UNIQUE NONCLUSTERED INDEX IX_Subscriber_Email
   ON buses (origin, destination,[time]);

   create table passengers(
   id int primary key,
origin varchar(10) not null,
destination varchar(10) not null,
[time] varchar(10) not null)

insert into buses values
(10,'Warsaw','Berlin','10:55'),
(20,'Berlin','Paris','06:20'),
(21,'Berlin','Paris','14:00'),
(22,'Berlin','Paris','21:40'),
(30,'Paris','Madrid','13:30')

insert into passengers values
(1,'Paris','Madrid','13:30'),
(2,'Paris','Madrid','13:31'),
(10,'Warsaw','Paris','10:00'),
(11,'Warsaw','Berlin','22:31'),
(40,'Berlin','Paris','06:15'),
(41,'Berlin','Paris','06:50'),
(42,'Berlin','Paris','07:12'),
(43,'Berlin','Paris','12:03'),
(44,'Berlin','Paris','20:50')

; WITH will_catch AS (
    SELECT p.id  pid, MIN(CAST(t.time AS TIME)) AS t_deptime
    FROM passengers p
    LEFT JOIN buses t ON t.origin = p.origin AND t.destination = p.destination
        AND CAST(t.time AS TIME) >= CAST(p.time AS TIME)
    GROUP BY p.id
)
SELECT t.id, COUNT(t_deptime)
FROM buses t
LEFT JOIN will_catch wc
on wc.t_deptime = CAST(t.time AS TIME)
GROUP BY t.id order by t.id
/*
Sample Input

ROUTE	StopNumber	ONS	OFFS	SPOT_CHECK
AAAA	1	5	0	NULL
AAAA	2	0	0	NULL
AAAA	3	2	1	NULL
AAAA	4	6	3	8
AAAA	5	1	0	NULL
AAAA	6	0	1	7
AAAA	7	0	3	NULL
Expected Output

ROUTE	StopNumber	ONS	OFFS	SPOT_CHECK	nxt	PassengerAtEveryStop
AAAA	1	5	0	NULL	5	5
AAAA	2	0	0	NULL	0	5
AAAA	3	2	1	NULL	1	6
AAAA	4	6	3	8	2	8
AAAA	5	1	0	NULL	1	9
AAAA	6	0	1	7	-2	7
AAAA	7	0	3	NULL	-3	4
Rules/Restrictions

The solution should be should use “SELECT” statement or “CTE”.
https://msbiskills.com/2015/05/09/t-sql-query-the-passengers-at-every-bus-stop-puzzle/
*/

CREATE TABLE BusLoad
( 
 
ROUTE CHAR(4) NOT NULL, 
StopNumber INT NOT NULL, 
ONS INT, 
OFFS INT, 
SPOT_CHECK INT
 
) 
go 
 
 
INSERT BusLoad VALUES('AAAA', 1, 5, 0, null) 
INSERT BusLoad VALUES('AAAA', 2, 0, 0, null) 
INSERT BusLoad VALUES('AAAA', 3, 2, 1, null) 
INSERT BusLoad VALUES('AAAA', 4, 6, 3, 8) 
INSERT BusLoad VALUES('AAAA', 5, 1, 0, null) 
INSERT BusLoad VALUES('AAAA', 6, 0, 1, 7) 
INSERT BusLoad VALUES('AAAA', 7, 0, 3, null) 
go 

;WITH CTE AS
(
      select *, nxt = ONS - offs - CASE WHEN Spot_Check IS NULL THEN 0 ELSE 1 END
      from Busload
)
SELECT *, SUM(nxt)  OVER (ORDER BY stopNUmber) PassengerAtEveryStop
FROM CTE t

/*
https://msbiskills.com/2016/07/12/sql-puzzle-getting-group-by-sum-and-total-sum-in-a-single-query/
SQL Puzzle | Getting group by sum and total sum in a single query

This puzzle is really cool. You have to get group by sum and total sum in a single query. Please check out the sample input and the expected output below-

Sample Input

ID	Val
1	10
1	NULL
2	NULL
2	100
2	200
3	200
3	100
4	156
4	255
4	244
4	NULL
4	NULL
4	345
Expected Output

ID	GroupBySum	TotalSum
1	10	1610
2	300	1610
3	300	1610
4	1000	1610
Rules/Restrictions

The solution should be should use “SELECT” statement or a CTE

*/
CREATE TABLE GroupBySumTotalSum
(
     ID INT
    ,VAL INT
)
GO
 
 
INSERT INTO GroupBySumTotalSum VALUES
(1, 10),
(1, NULL),
(2, NULL),
(2, 100),
(2, 200),
(3, 200),
(3, 100),
(4, 156),
(4, 255),
(4, 244),
(4, NULL),
(4, NULL),
(4, 345)
GO
 
CREATE CLUSTERED INDEX Ix_ID ON GroupBySumTotalSum(ID)
GO
--Sol 1
SELECT
       ID, SUM(Val) GroupBySum, SUM(SUM(Val)) OVER() TotalSum
FROM GroupBySumTotalSum
GROUP BY ID
-- Sol 2
SELECT DISTINCT ID, SUM(Val) OVER (PARTITION BY ID) GroupBySum, SUM(Val) OVER() TotalSum
FROM GroupBySumTotalSum
--sol 3
select id ID, SUM(Val) GroupBySum, (SELECT SUM(Val) FROM GroupBySumTotalSum ) TotalSum  FROM GroupBySumTotalSum group by ID


/*
https://msbiskills.com/2018/06/30/sql-puzzle-the-sum-puzzle-a-single-select/
In this puzzle you have to find the sum of val1 and val2 for each group and put that value at the begining of the group in the new column. The challenge here is to do this in a single select. For more details please see the sample input and expected output.

Sample Input

Id	Grp	Val1	Val2
1	1	30	29
2	1	19	0
3	1	11	45
4	2	0	0
5	2	100	17
Expected Output

Id	Grp	Val1	Val2	Tot
1	1	30	29	134
2	1	19	0	NULL
3	1	11	45	NULL
4	2	0	0	117
5	2	100	17	NULL


*/

CREATE TABLE MyData 
(
     Id INT
    ,Grp INT
    ,Val1 INT
    ,Val2 INT
)
GO
 
INSERT INTO MyData VALUES
(1,1,30,29),
(2,1,19,0),
(3,1,11,45),
(4,2,0,0),
(5,2,100,17)
GO
 
SELECT * FROM MyData
GO




--Using PARTITIONS
 
 
SELECT
   *,IIF(Id = MIN(Id) OVER (PARTITION BY Grp)
        , SUM(Val1) OVER (PARTITION BY Grp) + SUM(Val2) OVER (PARTITION BY Grp)
        ,NULL
        ) Tot
FROM MyData
 
--Note that SUM,count,min and MAX does not require ORDER BY Clause
 
 
/*
OUTPUT – 1 | Using PARTITIONS

 
Id          Grp         Val1        Val2        Tot
----------- ----------- ----------- ----------- -----------
1           1           30          29          134
2           1           19          0           NULL
3           1           11          45          NULL
4           2           0           0           117
5           2           100         17          NULL
 
*/

/*
https://msbiskills.com/2018/02/21/sql-puzzle-the-twin-max-puzzle-sql-interview-question-can-you-provide-a-better-solution/
SQL Puzzle | The TWIN MAX Puzzle 
n this puzzle you have to find records where you have maximum salary and maximum experience. Both the condition should be met to fetch the rows.

Please check the sample input and the expected output.

Sample Input

EmpId	Nm	Salary	Experience
1	Pawan	5000	11
2	Avtaar	1000	10
3	Kishan	5000	9
4	Ishu	1000	7
5	Nika	4500	11
6	Vaibhav	5000	5
Expected Output

EmpId	Nm	    Experience	Salary
1	    Pawan	11	        5000

*/

CREATE TABLE TheMaximumsPuzzle
(
     EmpId INT
    ,Nm VARCHAR(10)
    ,Salary INT
    ,Experience INT
)
GO
 
INSERT INTO TheMaximumsPuzzle VALUES
(1,'Pawan',5000,11),
(2,'Avtaar',1000,10),
(3,'Kishan',5000,9),
(4,'Ishu',1000,7),
(5,'Nika',4500,11),
(6,'Vaibhav',5000,5)
GO
 
SELECT * FROM TheMaximumsPuzzle
GO

--1
SELECT k.EmpId,k.Nm,k.Experience,k.Salary
FROM
(
    SELECT * , MAX(experience) OVER() a , MAX(Salary) OVER() b
    FROM TheMaximumsPuzzle
)k WHERE Salary = b AND Experience = a
 
 --2
 SELECT k.EmpId,k.Nm,k.Experience,k.Salary
FROM TheMaximumsPuzzle k
CROSS APPLY
(
    SELECT MAX(experience) a , MAX(Salary) b
    FROM TheMaximumsPuzzle
)z WHERE Salary = b AND Experience = a
 
 /*get nth highest salalry*/
 
create table employee(name varchar(50) not null, salary int not null)
 
insert into employee values('abc',100000),('bcd',1000000),('efg',40000),('ghi',500000)

select * from employee order by salary desc
go
WITH T AS
(
SELECT *,
   DENSE_RANK() OVER (ORDER BY Salary Desc) AS Rnk
FROM Employee
)
SELECT Name,salary
FROM T
WHERE Rnk=3;


 /*
 Advanced SQL | Fill the Price for missing months
https://msbiskills.com/2018/08/13/advanced-sql-fill-the-price-for-missing-months/

Advanced SQL | Fill the Price for missing months

In this puzzle you have to fill the price of SKU & Color Id for missing months. 
Note that SKU & Color Id should be considered as a business unit. So you have to set the previous value available to the missing month. Please check out the sample input and the expected output.
 https://msbiskills.com/tsql-puzzles-asked-in-interview-over-the-years/
 */
 CREATE TABLE SkuData
(
     SKU BIGINT
    ,ColorId BIGINT 
    ,Price DECIMAL(30,4)
    ,YM INT
)
GO
 
INSERT INTO SkuData VALUES
(1, 1,10,201801),
(1, 1,12,201804),  /* Price changed in 2018 April */
(2, 1,80,201704),  /* Started in the 2017 April */
(3, 1,28,201704),  /* Price changed for this product 4 times*/
(3, 1,20,201804),
(3, 1,19,201806),
(3, 1,27,201808)

 
SELECT * FROM SkuData
GO

DECLARE @StartYear AS INT = (SELECT MIN(LEFT(YM,4)) FROM SkuData)
;WITH CTE(Num) AS
(
    SELECT Number
    FROM (VALUES ('01'), ('02'), ('03'), ('04'), ('05'), ('06'), ('07'), ('08'),
    ('09'), ('10'),('11'),('12')) AS X(Number)
)
,SingleDigits(Number) AS
(
    SELECT Number
    FROM (VALUES (1), (2), (3), (4), (5), (6), (7), (8),
    (9), (0)) AS X(Number)
)
,Series AS
(
    SELECT (d1.Number+1) + (10*d2.Number) Number
    from
    SingleDigits as d1,
    SingleDigits as d2
)
,CTE2 AS
(
    SELECT  sku, colorId, CONCAT(xx,Num) * 1 Num FROM
    (
        SELECT * , (@StartYear+(Number-1)) xx  FROM Series
        CROSS JOIN CTE
        CROSS JOIN (SELECT DISTINCT Sku,ColorId FROM SkuData)x
        WHERE (@StartYear+(Number-1)) <= YEAR(GETDATE())
    )k  
)
,CTE3 AS
(
    SELECT x.ColorId , x.SKU , b.Price , b.YM ,x.Num FROM CTE2 x
    LEFT JOIN SkuData b ON x.Num = b.YM  AND x.ColorId = b.ColorId and x.SKU = b.SKU    
    WHERE Num <= CONCAT(YEAR(GETDATE()),RIGHT(CONCAT('0',MONTH(GETDATE())),2))
)
,CTE4 AS
(
    SELECT z.ColorId , z.SKU , z.Price , Num 
    ,ROW_NUMBER() OVER (PARTITION BY z.ColorId,z.SKU ORDER BY Num) rnk 
    FROM CTE3 z 
)
SELECT SKU,ColorId,ISNULL(Price,0) Price, Ym FROM
(
    SELECT a.SKU, a.ColorId,ISNULL(a.Price,r.Price) Price, Num Ym
    FROM CTE4 a
    OUTER APPLY (
                 SELECT TOP 1 rnk Mins FROM CTE4 x WHERE x.ColorId = a.ColorId AND x.SKU = a.SKU
                 AND a.rnk > x.rnk AND x.Price IS NOT NULL
                 ORDER BY x.Num DESC
                )x
    OUTER APPLY
               (
                 SELECT TOP 1 Price 
                 FROM CTE4 b             
                 WHERE b.rnk = x.Mins
                 AND a.ColorId = b.ColorId AND a.SKU = b.SKU
               )r
)z
ORDER BY Sku , ColorId,Ym

/*
leetcode 
https://leetcode.com/problems/consecutive-numbers/
Write an SQL query to find all numbers that appear at least three times consecutively.

Return the result table in any order.

The query result format is in the following example:

 

Logs table:
+----+-----+
| Id | Num |
+----+-----+
| 1  | 1   |
| 2  | 1   |
| 3  | 1   |
| 4  | 2   |
| 5  | 1   |
| 6  | 2   |
| 7  | 2   |
+----+-----+

Result table:
+-----------------+
| ConsecutiveNums |
+-----------------+
| 1               |
+-----------------+
1 is the only number that appears consecutively for at least three times.
*/

create table logs(Id int not null,Num int not null)
insert into logs values (1,1),(2,1),(3,1),(4,2),(5,1),(6,2),(7,2)

select * from logs
select  l1.Num as ConsecutiveNums
from 
Logs l1, 
Logs l2, 
Logs l3
where l1.Id = l2.Id-1
and l2.Id = l3.Id-1
and l1.Num=l2.Num
and l2.Num=l3.Num

/*
Department Top Three Salaries
The Employee table holds all employees. Every employee has an Id, and there is also a column for the department Id.
+----+-------+--------+--------------+
| Id | Name  | Salary | DepartmentId |
+----+-------+--------+--------------+
| 1  | Joe   | 85000  | 1            |
| 2  | Henry | 80000  | 2            |
| 3  | Sam   | 60000  | 2            |
| 4  | Max   | 90000  | 1            |
| 5  | Janet | 69000  | 1            |
| 6  | Randy | 85000  | 1            |
| 7  | Will  | 70000  | 1            |
+----+-------+--------+--------------+
The Department table holds all departments of the company.
+----+----------+
| Id | Name     |
+----+----------+
| 1  | IT       |
| 2  | Sales    |
+----+----------+
Write a SQL query to find employees who earn the top three salaries in each of the department. For the above tables, your SQL query should return the following rows (order of rows does not matter).
+------------+----------+--------+
| Department | Employee | Salary |
+------------+----------+--------+
| IT         | Max      | 90000  |
| IT         | Randy    | 85000  |
| IT         | Joe      | 85000  |
| IT         | Will     | 70000  |
| Sales      | Henry    | 80000  |
| Sales      | Sam      | 60000  |
+------------+----------+--------+
Explanation:
In IT department, Max earns the highest salary, both Randy and Joe earn the second highest salary, and Will earns the third highest salary. There are only two employees in the Sales department, Henry earns the highest salary while Sam earns the second highest salary.
*/
SELECT Department, Employee, Salary 
FROM (SELECT d.name Department, e.name Employee, e.salary Salary, DENSE_RANK() OVER (PARTITION BY d.id ORDER BY e.salary DESC) group_rank 
FROM employee e 
JOIN department d ON e.departmentid = d.id) sub 
WHERE group_rank < 4

/*
Department table:
+------+---------+-------+
| id   | revenue | month |
+------+---------+-------+
| 1    | 8000    | Jan   |
| 2    | 9000    | Jan   |
| 3    | 10000   | Feb   |
| 1    | 7000    | Feb   |
| 1    | 6000    | Mar   |
+------+---------+-------+
Result table:
+------+-------------+-------------+-------------+-----+-------------+
| id   | Jan_Revenue | Feb_Revenue | Mar_Revenue | ... | Dec_Revenue |
+------+-------------+-------------+-------------+-----+-------------+
| 1    | 8000        | 7000        | 6000        | ... | null        |
| 2    | 9000        | null        | null        | ... | null        |
| 3    | null        | 10000       | null        | ... | null        |
+------+-------------+-------------+-------------+-----+-------------+
Note that the result table has 13 columns (1 for the department id + 12 for the months).
*/
create table Department (id int,revenue int,month varchar(10))
insert into Department values (1,8000,'Jan'),(1,9000,'Feb'),(3,10000,'Feb'),(1,7000,'Feb'),(1,6000,'Mar')

SELECT id,
SUM(CASE WHEN month='Jan' THEN revenue END) AS 'Jan_Revenue',        
SUM(CASE WHEN month='Mar' THEN revenue END) AS 'Mar_Revenue',
SUM(CASE WHEN month='Apr' THEN revenue END) AS 'Apr_Revenue',
SUM(CASE WHEN month='Feb' THEN revenue END) AS 'Feb_Revenue', 
SUM(CASE WHEN month='May' THEN revenue END) AS 'May_Revenue',
SUM(CASE WHEN month='Jun' THEN revenue END) AS 'Jun_Revenue',
SUM(CASE WHEN month='Jul' THEN revenue END) AS 'Jul_Revenue',
SUM(CASE WHEN month='Aug' THEN revenue END) AS 'Aug_Revenue',
SUM(CASE WHEN month='Sep' THEN revenue END) AS 'Sep_Revenue',
SUM(CASE WHEN month='Oct' THEN revenue END) AS 'Oct_Revenue',
SUM(CASE WHEN month='Nov' THEN revenue END) AS 'Nov_Revenue',
SUM(CASE WHEN month='Dec' THEN revenue END) AS 'Dec_Revenue' 
FROM department 
GROUP BY id

/*
Weather
+----+------------+-------------+
| id | recordDate | Temperature |
+----+------------+-------------+
| 1  | 2015-01-01 | 10          |
| 2  | 2015-01-02 | 25          |
| 3  | 2015-01-03 | 20          |
| 4  | 2015-01-04 | 30          |
+----+------------+-------------+
Result table:
+----+
| id |
+----+
| 2  |
| 4  |
+----+
In 2015-01-02, temperature was higher than the previous day (10 -> 25).
In 2015-01-04, temperature was higher than the previous day (20 -> 30).
https://jwjin0330.medium.com/leetcode-sql-problems-%E2%91%A0-f1daada49809
*/
create table weather(id int,recorddate date,temperature int)
insert into weather values (1,'2015-01-01',10), (2,'2015-01-02',25), (3,'2015-01-03',20), (4,'2015-01-04',30)
SELECT *
FROM weather w1  
JOIN weather w2 ON w2.recordDate = DATEADD(DAY,1,w1.recorddate) 
WHERE w2.temperature > w1.temperature
/*
Employees Earning More Than Their Managers
The Employee table holds all employees including their managers. Every employee has an Id, and there is also a column for the manager Id.
+----+-------+--------+-----------+
| Id | Name  | Salary | ManagerId |
+----+-------+--------+-----------+
| 1  | Joe   | 70000  | 3         |
| 2  | Henry | 80000  | 4         |
| 3  | Sam   | 60000  | NULL      |
| 4  | Max   | 90000  | NULL      |
+----+-------+--------+-----------+
Given the Employee table, write a SQL query that finds out employees who earn more than their managers. For the above table, Joe is the only employee who earns more than his manager.
+----------+
| Employee |
+----------+
| Joe      |
+----------+
*/
SELECT e.name Employee 
FROM employee e 
INNER JOIN employee m ON e.managerID = m.ID 
WHERE e.salary > m.salary
/*
Delete Duplicate Emails
Write a SQL query to delete all duplicate email entries in a table named Person, keeping only unique emails based on its smallest Id.
+----+------------------+
| Id | Email            |
+----+------------------+
| 1  | john@example.com |
| 2  | bob@example.com  |
| 3  | john@example.com |
+----+------------------+
Id is the primary key column for this table.
For example, after running your query, the above Person table should have the following rows:
+----+------------------+
| Id | Email            |
+----+------------------+
| 1  | john@example.com |
| 2  | bob@example.com  |
+----+------------------+
*/
DELETE FROM person WHERE id IN 
(SELECT id
FROM (SELECT *, COUNT(email) OVER (PARTITION BY email) cnt, RANK() OVER (PARTITION BY email ORDER BY id) rnk
FROM person) sub
WHERE cnt > 1 AND rnk > 1)
/*

In this puzzle you have to have find the sum of sales for each employee. The catch here is that for inactive employees(IsActive=0) group the sum under Inactive name and rest under their respective names. Another catch is that you need to do this in a single select.Please check out the sample input and the expected output.

Sample Input

EmpName	SaleDate	SaleAmount	IsActive
Pawan	2018-08-07 10:18:28.663	2500.00	1
Pawan	2018-08-07 10:18:28.663	3000.00	1
Avtaar	2018-08-07 10:18:28.663	800.00	1
Avtaar	2018-08-07 10:18:28.663	1000.00	1
Kishan	2018-08-07 10:18:28.663	2800.00	1
Kishan	2018-08-07 10:18:28.663	3000.00	1
Nimit	2018-08-07 10:18:28.663	500.00	1
Nimit	2018-08-07 10:18:28.663	800.00	1
K	    2018-08-07 10:18:28.663	1000.00	0
L	    2018-08-07 10:18:28.663	1000.00	0
M	    2018-08-07 10:18:28.663	500.00	0
J	    2018-08-07 10:18:28.663	2500.00	0
Expected Output

EmpName	SaleAmount
Avtaar	1800.00
Inactive	5000.00
Kishan	5800.00
Nimit	1300.00
Pawan	5500.00
*/

CREATE TABLE dbo.tbl_sales
(  
    EmpName VARCHAR(256),
    SaleDate DATETIME,
    SaleAmount DECIMAL(18,2),
    IsActive BIT
)
GO
 
INSERT INTO tbl_sales VALUES
('Pawan',GETDATE(),2500.00,1),
('Pawan',GETDATE(),3000.00,1),
('Avtaar',GETDATE(),800.00,1),
('Avtaar',GETDATE(),1000.00,1),
('Kishan',GETDATE(),2800.00,1),
('Kishan',GETDATE(),3000.00,1),
('Nimit',GETDATE(),500.00,1),
('Nimit',GETDATE(),800.00,1),
('K',GETDATE(),1000.00,0),
('L',GETDATE(),1000.00,0),
('M',GETDATE(),500.00,0),
('J',GETDATE(),2500.00,0)
GO
 
SELECT * FROM tbl_sales
GO

SELECT DISTINCT IIF(IsActive = 0, 'Inactive',EmpName) EmpName , 
                SUM(SaleAmount) OVER (PARTITION BY  IIF(IsActive = 0, 'Inactive',EmpName))
                [SaleAmount]
FROM tbl_sales
GO

SELECT IIF(IsActive = 0, 'Inactive',EmpName) EmpName 
      ,SUM(SaleAmount) [SaleAmount]
FROM tbl_sales
GROUP BY IIF(IsActive = 0, 'Inactive',EmpName)
GO


/*
In this puzzle you have to count value a from all the columns preferably with a single select keyword. Please check out the sample input and the expected output.

Sample Input

a1	a2	a3
a	d	a
c	e	f
a	a	s
a	 	a
a	a	s
Expected Output

a1	a2	a3	CountOfA’s
a	d	a	8
c	e	f	8
a	a	s	8
a	 	a	8
a	a	s	8
Script – DDL and INSERT Sample Data
*/
CREATE TABLE Counta
(
      a1 VARCHAR(1)
    , a2 VARCHAR(1)
    , a3 VARCHAR(1)
)
GO
 
INSERT INTO Counta VALUES
('a','d','a'),
('c','e','f'),
('a','a','s'),
('a','','a'),
('a','a','s')
GO
 
SELECT * FROM Counta
GO
SELECT *    ,SUM(IIF(a1='a',1,0)) OVER()
            +SUM(IIF(a2='a',1,0)) OVER()
            +SUM(IIF(a3='a',1,0)) OVER() [CountOfA's]
FROM Counta

SELECT a.*,SUM(b.cnt) OVER() [CountOfA's]
FROM Counta a
CROSS APPLY
(
    SELECT COUNT(*) cnt
    FROM (VALUES (a1),(a2),(a3)) as t(v)
    WHERE t.v = 'a'
)b
/*
In this puzzle you have to provide the ranking in a new column. The logic for the ranking is that whenever you have a value “Product” then you have to start the new number and all other below should follow the same rank. Please check out the sample input and the expected output.

Sample Input

ID	Vals
1	Product
2	a
3	a
4	a
5	a
6	Product
7	b
8	b
9	Product
10	c
Expected Output

ID	Vals	x
1	Product	1
2	a	1
3	a	1
4	a	1
5	a	1
6	Product	2
7	b	2
8	b	2
9	Product	3
10	c	3
Script – DDL and INSERT Sample Data
*/
CREATE TABLE RankingPuzzle
(
     ID INT
    ,Vals VARCHAR(10)
)
GO
 
INSERT INTO RankingPuzzle VALUES
(1,'Product'),
(2,'a'),
(3,'a'),
(4,'a'),
(5,'a'),
(6,'Product'),
(7,'b'),
(8,'b'),
(9,'Product'),
(10,'c')
GO
 
SELECT * FROM RankingPuzzle a
GO
SELECT * ,
            (
                SELECT COUNT(*) cnt
                FROM RankingPuzzle b
                WHERE B.ID <= a.Id AND b.Vals = 'Product'
            )x
FROM RankingPuzzle a
SELECT *, 
    SUM(IIF(Vals = 'Product',1,0)) OVER (ORDER BY Id) cnt
FROM RankingPuzzle

--Synonyms will not show up in sp_help but while creation yu can use them
/*
This is something really interesting. Here you have to join these two tables and provide the resulted data but the matching rows into Multiple Rows. The Challenge here is to do this without using UNION/UNION ALL. Please check out the sample input and the expected output.

Sample Input

Table 1 –

Id	Vals
1	Pawan
2	Sharlee
3	Harry
Table 2 –

Id	Vals
1	Kumar
2	Diwan
Expected Output

Id	Vals
1	Pawan
1	Kumar
2	Sharlee
2	Diwan
*/
SELECT Id,Vals FROM
(
    SELECT ISNULL(a.Id,B.Id) Id, ISNULL(a.Vals,B.Vals) Vals , COUNT(*) OVER (PARTITION BY ISNULL(a.Id,B.Id)) cnt
    FROM T1N1 a
    FULL OUTER JOIN T1N2 b ON a.Id = B.Id and a.Vals = b.Vals
)z WHERE cnt > 1
/*
Get first record from FirstTab table i.e. 1 and insert that record into table SecondTab and ThirdTab with a single INSERT keyword. 
Basically you cannot use Multiple INSERT statements

*/
CREATE TABLE FirstTab
(
    Id INT
)
GO
 
INSERT INTO FirstTab VALUES (1),(2)
GO
 
CREATE TABLE SecondTab
(
    Id INT
)
GO
 
CREATE TABLE ThirdTab
(
    Id INT
)
GO
 
INSERT INTO SecondTab
OUTPUT inserted.Id INTO ThirdTab
SELECT Id FROM FirstTab
WHERE Id = 1
 
 /*
 left right node tree
 */
 
 CREATE TABLE TheLeftRight 
(
   PId INT NOT NULL
  ,[Left]  INT
  ,[Right] INT
)
GO
 
INSERT INTO TheLeftRight VALUES
(1,2,3),
(2,4,5),
(3,6,7),
(10,NULL,NULL),
(9,8,NULL)
GO
 
SELECT * FROM TheLeftRight
GO
 SELECT *
FROM  TheLeftRight U
RIGHT JOIN TheLeftRight T1
ON (u.[Left]=T1.PId or u.[Right]=T1.PId )
WHERE u.PId IS NULL
/*Prev Current values*/
CREATE TABLE TheNextAndPreviousPuzzle
(
     Id INT
    ,PreviousVals int
    ,CurrentVals int   
)
GO
 
INSERT INTO TheNextAndPreviousPuzzle VALUES
(1,11,15),
(2,15,31),
(3,31,9),
(4,27,12),
(5,12,11)
GO
 
SELECT * FROM TheNextAndPreviousPuzzle
GO
SELECT DISTINCT T.* FROM TheNextAndPreviousPuzzle t inner join TheNextAndPreviousPuzzle t1 on
(((t.CurrentVals = t1.PreviousVals) OR (t1.CurrentVals = t.PreviousVals))  AND t1.CurrentVals = 31) 
OR t.CurrentVals = 31

/*you have to concat columns Nm and Val if they were not already concatenated at the beginning in Val column*/
SELECT *, IIF(CHARINDEX(Nm,Val)=0,CONCAT(Nm,Val),Val) NewVal FROM TheConcatPuzzle
GO

/*
read the JSON column to get Skills and Id value for each Name
Sample Input

Nn	Val
Kishan	[{“Id”:”3?,”Skills”:”mySQL SERVER”}]
Pawan	[{“Id”:”1?,”Skills”:”SQL SERVER”},{“Id”:”11?,”Skills”:”Oracle”}]
Avtaar	[{“Id”:”2?,”Skills”:”T-SQL”}]
Expected Output

Nm	Skills	Id
Kishan	mySQL SERVER	3
Pawan	SQL SERVER	1
Pawan	Oracle	11
Avtaar	T-SQL	2
Script – DDL and INSERT Sample Data
*/
CREATE TABLE TheJSONS
(
     Nn VARCHAR(10)
    ,Val VARCHAR(100)
)
GO
 
INSERT INTO TheJSONS VALUES
('Kishan','[{"Id":"3","Skills":"mySQL SERVER"}]'),
('Pawan','[{"Id":"1","Skills":"SQL SERVER"},{"Id":"11","Skills":"Oracle"}]'),
('Avtaar','[{"Id":"2","Skills":"T-SQL"}]')
GO
 
SELECT * FROM TheJSONS
GO

SELECT Nn Nm,Skills,Id
FROM TheJSONS
CROSS APPLY
OPENJSON (Val) WITH (Id INT'$.Id',Skills VARCHAR(20) '$.Skills')
 
/*
In this puzzle you have to ignore the Transpose Record. Example. For the below 2 records we need any one record-

(1,10,15),
(1,15,10)

For more details please see the sample input and expected output.

Sample Input

Id	Vals1	Vals2
1	10	15
1	15	10
2	10	20
2	20	10
3	10	15
4	10	10
4	10	10
Expected Output

Id	Vals1	Vals2
1	10	15
2	10	20
3	10	15
4	10	10
*/

CREATE TABLE DuplicateRecs
(
	 Id INT 
	,Vals1 INT   
	,Vals2 INT
)
GO

INSERT INTO DuplicateRecs VALUES
(1,10,15),
(1,15,10),
(2,10,20),
(2,20,10),
(3,10,15)
GO

INSERT INTO DuplicateRecs VALUES
(4,10,10),
(4,10,10)
GO

SELECT * FROM DuplicateRecs
GO

SELECT Id,Vals1,Vals2 from
(
	SELECT * , ROW_NUMBER() OVER(PARTITION BY id,vals1+vals2 order by id) rnk
	FROM DuplicateRecs
)x WHERE rnk = 1 

/*
string split
*/
DECLARE @ AS VARCHAR(MAX) = 'Pawan1,Pawan2,Pawan4,Pawan3'
SELECT VALUE FROM
(
    SELECT VALUE , ROW_NUMBER() OVER (ORDER BY (SELECT 1)) rnk FROM STRING_SPLIT(@, ',')
)x where rnk = 3
GO
/*
Multi column search without OR
In this puzzle you have to find out rows where we have pawan in any of the column. The restriction is that you cannot use the OR statement as we have N number of columns as it looks bad if we use some many columns with OR condition. For more details please see the sample input and expected output.

Sample Input

a	b	c	d	e	f
Pawan	P	K	Manmeet	NULL	Avtaar
A	Avtaar	Pawan	NULL	Sharlee	NULL
NULL	Pawan	A	Manmeet	Sharlee	Avtaar
Manmeet	Pawan	NULL	Sharlee	A	Pawan
NULL	Avtaar	Z	M	Z	K
NULL	Pawan	Q	Manmeet	T	Sharlee
Manmeet	T	Avtaar	NULL	Sharlee	Z
Expected Output

a	b	c	d	e	f	rnk
Pawan	P	K	Manmeet	NULL	Avtaar	1
A	Avtaar	Pawan	NULL	Sharlee	NULL	2
NULL	Pawan	A	Manmeet	Sharlee	Avtaar	3
Manmeet	Pawan	NULL	Sharlee	A	Pawan	4
NULL	Pawan	Q	Manmeet	T	Sharlee	6
Script – DDL and INSERT Sample Data
*/
CREATE TABLE TheMultiCheckingCondition 
(   
      a VARCHAR(10)
    , b VARCHAR(10)
    , c VARCHAR(10)
    , d VARCHAR(10)
    , e VARCHAR(10)
    , f VARCHAR(10)
 
)
GO
 
INSERT INTO TheMultiCheckingCondition values
('Pawan','P','K','Manmeet',NULL,'Avtaar'),
('A','Avtaar','Pawan',NULL,'Sharlee',NULL),
(NULL,'Pawan','A','Manmeet','Sharlee','Avtaar'),
('Manmeet','Pawan',NULL,'Sharlee','A','Pawan'),
(NULL,'Avtaar','Z','M','Z','K'),
(NULL,'Pawan','Q','Manmeet','T','Sharlee'),
('Manmeet','T','Avtaar',NULL,'Sharlee','Z')
GO
 
SELECT * FROM TheMultiCheckingCondition
GO

;WITH CTE AS
(
    SELECT *, ROW_NUMBER() OVER (Order by (SELECT NULL)) rnk
    FROM TheMultiCheckingCondition
)
SELECT c.* FROM CTE c
CROSS APPLY 
(
    SELECT * FROM CTE c1 WHERE c1.rnk = c.rnk 
    FOR XML RAW('w')
)z(t)
WHERE z.t LIKE '%pawan%'

/*
In this puzzle you have to convert the columns into rows without using the UNVPIVOT command. For more details please see the sample input and expected output.

Sample Input

ProjectName	Dev Start Date	        Dev End Date	        Testing Plan Date	        Testing End Date
P1	        2017-01-01 00:00:00.000	2017-06-01 00:00:00.000	2017-06-04 00:00:00.000	2017-08-24 00:00:00.000
P2	        2016-06-01 00:00:00.000	2017-01-01 00:00:00.000	2017-01-10 00:00:00.000	2017-02-26 00:00:00.000
P3	        2014-03-01 00:00:00.000	2015-03-25 00:00:00.000	2015-04-01 00:00:00.000	2015-07-20 00:00:00.000
P4	        2012-02-01 00:00:00.000	2012-10-29 00:00:00.000	2012-11-10 00:00:00.000	2013-02-05 00:00:00.000
Expected Output

ProjectName	WorkType	    StDt	                EnDt
P1	        Developement	2017-01-01 00:00:00.000	2017-06-01 00:00:00.000
P2	        Developement	2016-06-01 00:00:00.000	2017-01-01 00:00:00.000
P3	        Developement	2014-03-01 00:00:00.000	2015-03-25 00:00:00.000
P4	        Developement	2012-02-01 00:00:00.000	2012-10-29 00:00:00.000
P1	        Testing	        2017-06-04 00:00:00.000	2017-08-24 00:00:00.000
P2	        Testing	        2017-01-10 00:00:00.000	2017-02-26 00:00:00.000
P3	        Testing	        2015-04-01 00:00:00.000	2015-07-20 00:00:00.000
P4	        Testing	        2012-11-10 00:00:00.000	2013-02-05 00:00:00.000
Script – DDL and INSERT Sample Data

*/


SELECT ProjectName,z.* 
FROM MyProject
CROSS APPLY
(VALUES
    (
        'Developement' , [Dev Start Date],  [Dev End Date]
    ),
    (
        'Testing' , [Testing Plan Date] ,  [Testing End Date]
    )
)z
(
    WorkType,StDt, EnDt
)

/*
find common id
*/
SELECT Id FROM TheIntersect I
WHERE ValId IN ( 1 , 4 )
AND EXISTS 
(
    SELECT * FROM TheIntersect b
    WHERE ValId IN ( 3 , 2 )
    AND I.Id = b.Id
) 
/*
Well It is one of the most interesting interview questions I have. Find all the rows where ID IS not in (‘Id9’, ‘Id10’, ‘Id11’) and If the ID is in (‘Id9’, ‘Id10’, ‘Id11’) with num columns value is greater than 0 the we also need to include that rows. One restriction is that we cannot use the UNION or UNION ALL in this question. ?? . You also need to find out rows where .For more details please see the sample input and expected output.

Sample Input

Num	Vals	Id	Description
5	2	Id6	T1
5	2	Id7	T2
5	2	Id8	T3
1	2	Id9	T4
0	2	Id10	T5
0	2	Id11	T6
Expected Output

Num	Vals	Id	Description
5	2	Id6	T1
5	2	Id7	T2
5	2	Id8	T3
1	2	Id9	T4
Script – DDL and INSERT Sample Data

*/
CREATE TABLE TheNOTIn
(
     Num INT
    ,Vals INT
    ,Id VARCHAR(10)
    ,[Description] VARCHAR(5)
)
GO
 
INSERT INTO TheNOTIn VALUES
(5,2,'Id6','T1'),
(5,2,'Id7','T2'),
(5,2,'Id8','T3'),
(1,2,'Id9','T4'),
(0,2,'Id10','T5'),
(0,2,'Id11','T6')
GO
 
SELECT * FROM TheNOTIn 
GO

SELECT * 
FROM TheNOTIn
WHERE
1 = CASE WHEN ID NOT IN ('Id9', 'Id10', 'Id11') THEN 1 
         WHEN ID IN ('Id9', 'Id10', 'Id11') AND Num > 0 THEN 1 
    ELSE 2
    END
 
/*
In this puzzle you have to go through the SQL statement given below and provide us the output without executing the SQL on SSMS or any other onsite SQL tool
*/
CREATE TABLE TheAssignmentPuzzle 
(
     Id INT
    ,Vals INT
)
GO
 
INSERT INTO TheAssignmentPuzzle VALUES
(1,10),
(2,20),
(3,30)
GO
 
SELECT * FROM TheAssignmentPuzzle
GO
 
DECLARE @ INT
SELECT @ 
    = MAX(Vals) FROM
TheAssignmentPuzzle GROUP BY Id
SELECT @
GO
/*Last friday*/
DECLARE @StartDate AS DATETIME ='10-July-2010'
DECLARE @DayName AS VARCHAR(20) = 'Friday'
SELECT DATEADD(d, -1 * ((DATEPART(dw,EOMONTH(@StartDate)) + 1) % 7), EOMONTH(@StartDate)) [Last-Friday of Month]
 
/*
All presence values
*/
DECLARE @Vals AS VARCHAR(MAX) = 'A1,A2,A3'
;WITH CTE AS
(
    SELECT value vals , COUNT(*) OVER() cnt FROM STRING_SPLIT(@Vals,',')
)
,CTE1 AS
(
    SELECT * , COUNT(*) OVER (PARTITION BY a.dat) cnt
    FROM TestAll a 
)
SELECT c1.Id,c1.Dat,c1.Vals FROM CTE1 c1 INNER JOIN CTE c 
ON c.cnt = c1.cnt AND c1.Vals = c.vals

/*only one type*/
CREATE TABLE OnlyOneType
(
     Id INT
    ,[Type] INT
    ,Vals DECIMAL(10,2)
)
GO
 
INSERT INTO OnlyOneType VALUES
(1,3 ,900.00 ),
(1,3 ,200.00 ),
(1,3 ,800.00 ),
(1,21,200.00 ),
(2,21,100.00  ),
(2,21,100.00  ),
(3,3 ,100.00 ),
(3,3 ,100.00 ),
(4,21,100.00)
GO
 
SELECT * FROM OnlyOneType T
GO
 SELECT * FROM OnlyOneType T
WHERE [Type] = 21
AND NOT EXISTS ( SELECT NULL FROM OnlyOneType T1 WHERE T1.Id = T.Id and T1.Type <> 21 )

/*
In this puzzle you have to count the number of records where the Vals is decreased by more than 2 between current & previous records. Please see the sample input and expected output.

Sample Input

Dt	Vals
2015-09-13 16:11:00.000	10
2015-09-13 16:16:00.000	11
2015-09-13 16:21:00.000	12
2015-09-13 16:26:00.000	11
2015-09-13 16:31:00.000	9
2015-09-13 16:36:00.000	10
2015-09-13 16:41:00.000	12
2015-09-13 16:46:00.000	9
2015-09-13 16:46:00.000	3
Expected Output

Count
3
*/
CREATE TABLE GetDiffOfTwo
(
     Dt DATETIME
    ,Vals INT
)
GO
 
INSERT INTO GetDiffOfTwo(Vals,dt) VALUES
(10,'2015-09-13 16:11:00.000'),
(11,'2015-09-13 16:16:00.000'),
(12,'2015-09-13 16:21:00.000'),
(11,'2015-09-13 16:26:00.000'),
(9 ,'2015-09-13 16:31:00.000'),
(10,'2015-09-13 16:36:00.000'),
(12,'2015-09-13 16:41:00.000'),
(9 ,'2015-09-13 16:46:00.000'),
(3 ,'2015-09-13 16:46:00.000')
GO
 
SELECT * FROM GetDiffOfTwo
GO

;WITH CTE AS
(
    SELECT IIF(Vals- ISNULL(LAG(Vals) OVER (ORDER BY Dt ASC),Vals)<-1,1,0) cnt FROM GetDiffOfTwo
)
SELECT SUM(cnt) [Count] FROM CTE

--Insert into identity column 
CREATE TABLE IdentityTable
(
    Id INT IDENTITY(1,1)
)
GO
INSERT INTO IdentityTable DEFAULT VALUES
GO 10
/*
in the puzzle you have to show child data in from of the parent Id. For more details please refer sample input and expected output.

Sample Input

MainTable

Id	Vals
1	I am here
2	Yes I am here
3	Are you sure
4	Ok
DependentTable

Id	ChildId
1	2
3	4
Expected output

ParentId	ParentDesc	ChilId	ChildDesc
1	        I am here	    2	Yes I am here
3	        Are you sure	4	Ok
Script – DDL and INSERT sample data
*/

--
 
CREATE TABLE MainTable
(
      Id INT
    , Vals VARCHAR(100)
)
GO
 
INSERT INTO MainTable VALUES
(1,'I am here'),
(2,'Yes I am here'),
(3,'Are you sure'),
(4,'Ok')
GO
 
CREATE TABLE DependentTable
(
     Id INT
    ,ChildId INT
)
GO
 
INSERT INTO DependentTable VALUES
(1,2),
(3,4)
GO
 
SELECT * FROM MainTable
GO
SELECT * FROM DependentTable
GO
 
 
SELECT
    T1.Id ParentId, T1.Vals ParentDesc, T3.Id ChilId,T3.Vals ChildDesc
FROM
MainTable T1
INNER JOIN DependentTable T2 ON T1.Id= T2.Id
INNER JOIN MainTable T3 ON T3.Id= T2.ChildId

/*
SUM EVERY 3 rows for each Id Puzzle 
n this puzzle you have to get SUM of every 3 rows of Val column for each Id

1 : First 3 rows should be combined together, then next 3 rows.
2 : If you have less then 3 rows then also we need to go ahead and combine the rows.

For more details please refer sample input and expected output.

Sample Input

Id	Nums	Val
1	101	10
1	102	5
1	103	10
1	104	20
2	105	25
2	106	10
2	107	15
2	108	45
2	109	5
3	110	0
3	111	10
3	112	20
3	113	80
3	114	20
3	115	5
4	116	10
Expected output

Id	Nums	Val	3Sums
1	101	    10	25
1	102	    5	25
1	103	    10	25
1	104	    20	20
2	105	    25	50
2	106	    10	50
2	107	    15	50
2	108	    45	50
2	109	    5	50
3	110	    0	30
3	111	    10	30
3	112	    20	30
3	113	    80	105
3	114	    20	105
3	115	    5	105
4	116	    10	10
*/

 
CREATE TABLE TheThreeGroups
(
     Id INT
    ,Nums INT
    ,Val INT
)
GO
 
INSERT INTO TheThreeGroups VALUES
(1,101,10),
(1,102,5),
(1,103,10),
(1,104,20),
(2,105,25),
(2,106,10),
(2,107,15),
(2,108,45),
(2,109,5),
(3,110,0),
(3,111,10),
(3,112,20),
(3,113,80),
(3,114,20),
(3,115,5),
(4,116,10)
GO
 
SELECT * FROM TheThreeGroups
GO

SELECT Id, Nums, Val , SUM(Val) OVER(PARTITION BY Id,rnk) [3Sums] FROM
(
    SELECT * , (ROW_NUMBER() OVER(PARTITION BY Id ORDER BY Nums) - 1) / 3 rnk FROM TheThreeGroups
)k
GO
 
/*
 THE Order BY CASE Puzzle 
 In this puzzle you have to sort data based on the Id but Id with 0 should always be the last row. Now the question is can you do that with a single order by column.

For more details please refer sample input and expected output.

Sample Input

Id	Vals
0	All
1	Pawan
2	Avtaar
3	Kishan
4	Vaibhav
5	Ashutosh
Expected output

Id	Vals
1	Pawan
2	Avtaar
3	Kishan
4	Vaibhav
5	Ashutosh
0	All
*/

CREATE TABLE SingleOrder
(
     Id INT
    ,Vals VARCHAR(10)
)
GO
 
INSERT INTO SingleOrder VALUES
(0,'All'),
(1,'Pawan'),
(2,'Avtaar'),
(3,'Kishan'),
(4,'Vaibhav'),
(5,'Ashutosh')
GO
 
SELECT * FROM SingleOrder order by id
GO
SELECT * FROM SingleOrder
ORDER BY CASE WHEN Id = 0 THEN MAX(ID) OVER ()+1 ELSE ID END
/*
 In this puzzle you have to find string with multiple characters. The length of the string should be greater than 1 and all the characters should be same. For more details please refer the sample input and expected output.

Sample Input

Id	Vals
1	aa
2	cccc
3	abc
4	aabc
5	NULL
6	a
7	zzz
8	abc
Expected Output

Id	Vals
1	aa
2	cccc
7	zzz
Script to create table and insert sample date
*/ 
CREATE TABLE FindSameCharacters
(
     Id INT
    ,Vals VARCHAR(10)
)
GO
 
INSERT INTO FindSameCharacters VALUES
(1,'aa'),
(2,'cccc'),
(3,'abc'),
(4,'aabc'),
(5,NULL),
(6,'a'),
(7,'zzz'),
(8,'abc')
GO
 
SELECT * 
FROM FindSameCharacters
GO
 
 SELECT * 
FROM FindSameCharacters
WHERE LEN(Vals) > 1 AND LEN(REPLACE(Vals,SUBSTRING(Vals,1,1),'')) = 0
GO

/*
you have to find the SUM of vals1, Vals2 and vals3 column for each Id and Vals column and you need show that after each group. For more details please refer sample input and expected output

Sample INPUT

Id	Vals	Vals1	Vals2	Vals3
A	S1	103	53	3
A	S2	45	31	12
A	S3	10	21	23
B	S3	67	19	8
B	S4	20	22	1
B	S5	20	1	25
Expected OUPUT

Title	Id	Vals	Vals1	Vals2	Vals3
 	A	S1	103	53	3
 	A	S2	45	31	12
 	A	S3	10	21	23
SubGroup Total	A	NULL	158	105	38
 	B	S3	67	19	8
 	B	S4	20	22	1
 	B	S5	20	1	25
SubGroup Total	B	NULL	107	42	34
Total	NULL	NULL	265	147	72
Use below script to create table and insert sample data into it.
*/

CREATE TABLE GroupsAndTotalData
(
    Id VARCHAR(10),
    Vals VARCHAR(50),
    Vals1 INT,
    Vals2 INT,
    Vals3 INT
) 
GO  
  
INSERT INTO GroupsAndTotalData VALUES
('A','S1',103,53,3),
('A','S2',45,31,12),
('A','S3',10,21,23),
('B','S3',67,19,8) ,
('B','S4',20,22,1) ,
('B','S5',20,1,25) 
GO
  
SELECT * FROM GroupsAndTotalData
GO
SELECT
  CASE
    WHEN GROUPING_ID(Id,Vals) = 3 THEN 'Total'
    WHEN GROUPING_ID(Id,Vals) = 1 THEN 'SubGroup Total'
    WHEN GROUPING_ID(Id,Vals) = 0 THEN ''
  END Title,
  Id
  ,Vals
  ,SUM(Vals1) Vals1
  ,SUM(Vals2) Vals2
  ,SUM(Vals3) Vals3
FROM
GroupsAndTotalData
GROUP BY GROUPING SETS
(
    (Id,Vals),
    (Id),
    ()
)

/*
CHeck leap year/
There are two types of Years – Leap year and Non Leap year. Lets first understand what are they-

Leap Year

A normal year has 365 days.
A Leap Year has 366 days (the extra day is the 29th of February).
How to know if a year will be a Leap Year:
	Leap Years are any year that can be evenly divided by 4 (such as 2012, 2016, etc)
	except if it can can be evenly divided by 100, then it isn’t (such as 2100, 2200, etc)
	except if it can be evenly divided by 400, then it is (such as 2000, 2400)
*/
DECLARE @Yr INT = 1900
SELECT @Yr [Year] , IIF ((@Yr % 4 = 0 AND @Yr % 100 != 0) OR @Yr % 400 = 0, 'Leap Year','Not a Leap Year')
    [IsLeapYear]
 
GO

/*
In this puzzle you have to generate a new column called Flagger The criteria is for each Vals last row the flagger should be 0 all else is 1.

Please check the sample input and the expected output.

Sample Input

Id	Vals
101	SQL
102	SQL
103	Oracle
104	Oracle
105	Oracle
106	DB2
107	DB2
108	mySQL
109	mySQL
110	mySQL
111	mySQL
Expected Output

Id	    Vals	Flagger
101	    SQL	        1
102	    SQL	        0
103	    Oracle	    1
104	    Oracle	    1
105	    Oracle	    0
106	    DB2	        1
107	    DB2	        0
108	    mySQL	    1
109	    mySQL	    1
110	    mySQL	    1
111	    mySQL	    0
Use     below script to create table and insert sample data into it.
*/

CREATE TABLE CreateFlagger
(
     Id INT
    ,Vals VARCHAR(10)
)
GO
 
INSERT INTO CreateFlagger VALUES
(101,'SQL'),
(102,'SQL'),
(103,'Oracle'),
(104,'Oracle'),
(105,'Oracle'),
(106,'DB2'),
(107,'DB2'),
(108,'mySQL'),
(109,'mySQL'),
(110,'mySQL'),
(111,'mySQL')
GO
 
SELECT * FROM CreateFlagger
GO

SELECT * , CASE WHEN FIRST_VALUE(Id) OVER (PARTITION BY Vals ORDER BY Id DESC) = Id THEN 0 ELSE 1 END Flagger
FROM CreateFlagger
ORDER BY Id

/*
In the puzzle you have to find records where records have same length what the length records A has. In below data record A has length 5. So we have to first find the length of record A and then we have to find records with the same length what A has. In this case we need record D as the output. Please check the sample input and the expected output.

Notes –
1. We do not need A in the output.
2. The limitation is that we can only use a single SELECT for the puzzle.

Sample Input

Id	Name	Length
1	A	5
2	B	3
3	C	4
4	D	5
Expected Output

Id	Name	Length
1	D	5
Script

Use below script to create table and insert sample data into it.
*/

CREATE TABLE FindRecordsWithALength
(
     Id INT
    ,[Name] VARCHAR(10)
    ,[Length] INT
)
GO
 
INSERT INTO FindRecordsWithALength VALUES
(1,'A',5),
(2,'B',3),
(3,'C',4),
(4,'D',5)
GO
 
SELECT * FROM FindRecordsWithALength
GO
SELECT b.* FROM FindRecordsWithALength a
INNER JOIN FindRecordsWithALength b  ON a.Name = 'A'
AND a.Length = b.Length AND a.Id != b.Id
GO
/*
Employees count in Active Departments Puzzle | Frequent SQL SERVER Interview Question

In this puzzle you have to find count of employees present in each active departments. Please check the sample input and the expected output. The challenge is to do this in a single select.

Note – Few of my colleagues frequently asks this question in technical interviews.

Sample Input

Employee Table

EmpId	Name	DeptId
1	Pawan	1
2	Ramesh	2
3	Krishan	1
Departments TABLE

DeptId	DeptName	IsActive
1	A	1
2	B	1
3	C	1
4	D	0
Expected Output

DeptName	Active	countof emp
A	1	2
B	1	1
C	1	1
Script

Use below script to create table and insert sample data into it.
*/

CREATE TABLE Departments
(
	 DeptId INT
	,DeptName VARCHAR(10)
	,IsActive INT
)
GO

INSERT INTO Departments VALUES
(1 , 'A' ,1	),
(2 , 'B' ,1	),
(3 , 'C' ,1	),
(4 , 'D' ,0	)
GO

CREATE TABLE Emps
(
	 EmpId INT
	,[Name] VARCHAR(10)
	,DeptId INT
)
GO

INSERT INTO Emps VALUES
(1,'Pawan',1),
(2,'Ramesh',2),
(3,'Krishan',1)
GO
SELECT D.DeptName , 1 Active , COUNT(E.EmpId) [countof emp] FROM Departments D
LEFT JOIN Emps E ON D.DeptId = E.DeptId
WHERE D.IsActive = 1
GROUP BY D.DeptName

/*
Find Minimum Value from Multiple Columns Puzzle

In this puzzle you have to find minimum value from multiple columns other than the NULL and zero value. For more details please check the sample input and expected output.

Sample Input

Id	a	b	c	d	e	f
1	NULL	0	918.09	162.12	NULL	675.72
2	NULL	0	761.09	19.12	NULL	231.72
Expected Output

Id	MinimumValue
1	162.12
2	19.12
Script

Use below script to create table and insert sample data into it.

*/
CREATE TABLE FindMinimumNotNULL
(
     Id INT
    ,a INT
    ,b INT
    ,c DECIMAL(10,2)
    ,d DECIMAL(10,2)
    ,e INT
    ,f DECIMAL(10,2)
)
GO
 
INSERT INTO FindMinimumNotNULL (Id,a,b,c,d,e,f) Values
(1,NULL,0,918.09,162.12,NULL,675.72),
(2,NULL,0,761.09,19.12,NULL,231.72)
GO
 
SELECT * FROM FindMinimumNotNULL
GO
SELECT Id,
(
       SELECT MIN(v)
       FROM
       (
          VALUES (a) , (b), (c) ,(d) ,(e) , (f) 
       ) as value(v)
       WHERE v > 0
) as MinimumValue 
FROM FindMinimumNotNULL 

/*Temporary result set without inserting into another table*/

SELECT *
FROM (VALUES (1,2),(3,4),(340,455)) AS x(a,b)
--find out rows where you have at least one integer value or one alphabet in a single SELECT 
SELECT *
FROM (VALUES ('Paw# 67'),
('Pa67'),
('21(Pawan)'),
('Pawan''s'),
('Pawan I'),
('$'),
('((****(((()))')) AS x(a)  WHERE a LIKE '%[a-zA-Z0-9]%'

/*
In this puzzle you have to club the sequence data together. For more details please check the sample input and expected output.

Sample Input

Id
1
2
3
4
8
9
14
15
16
17
Expected Output

Ouptut
1-4, 8-9, 14-17
Script
*/

CREATE TABLE CreateSequence
(
    Id INT
)
GO
 
INSERT INTO CreateSequence VALUES
(1 ),
(2 ),
(3 ),
(4 ),
(8 ),
(9 ),
(14),
(15),
(16),
(17)
GO
 
SELECT * FROM CreateSequence
GO

 
;WITH CTE AS
(
    SELECT CONCAT(MIN(Id),'-',MAX(Id)) Id
    FROM
    (
        SELECT Id, SUM(a) OVER (Order BY Id) Grouper
        FROM 
        (
            SELECT * ,IIF(Id -  ISNULL(LAG(Id) OVER (ORDER BY Id),0)>1,1,0) a FROM
            CreateSequence 
        ) l
    )x GROUP BY Grouper
)
SELECT DISTINCT 
      STUFF 
        ((
            SELECT ', ' + Id
            FROM CTE a
            FOR XML PATH('')
        ) ,1,2,'') 
        AS Ouptut
FROM CTE
 
/*
In this puzzle the requirement is you have to write a SINGLE T-SQL to get Minimum balance, Average balance, Maximum Balance and last and first value of balance per month and account. Please see expected output and input for more details. . For more details please check the sample input and expected output.

Sample Input

Id	Acct	Months	Bal
1	10011	1	345
2	10011	1	122
3	10011	1	190
4	10011	2	111
5	10011	3	2300
6	10011	3	87820
7	10012	1	345
8	10012	1	190
9	10012	3	5000
10	10012	3	1500
11	10012	3	7000
Expected Output

Id	Acct	Months	Bal	    MinimumBalance	AverageBalance	MaximumBalance	FirstValue	LastValue
1	10011	1	    345	    122	            219.000000	    345	            345	        190
2	10011	1	    122	    122	            219.000000	    345	            345	        190
3	10011	1	    190	    122	            219.000000	    345	            345	        190
4	10011	2	    111	    111	            111.000000	    111	            111	        111
5	10011	3	    2300	2300	        45060.000000    87820	        2300	    87820
6	10011	3	    87820	2300	        45060.000000    87820	        2300	    87820
7	10012	1	    345	    190	            267.500000	    345	            345	        190
8	10012	1	    190	    190	            267.500000	    345	            345	        190
9	10012	3	    5000	1500	        4500.000000	    7000	        5000	    7000
10	10012	3	    1500	1500	        4500.000000	    7000	        5000	    7000
11	10012	3	    7000	1500	        4500.000000	    7000	        5000	    7000
Script
*/

CREATE TABLE GetMinMaxAvgVal
(
     Id INT
    ,Acct INT
    ,Months INT  
    ,Bal INT
)
GO
 
INSERT INTO GetMinMaxAvgVal VALUES
(1, 10011, 1, 345),
(2, 10011, 1, 122),
(3, 10011, 1, 190),
(4, 10011, 2, 111),
(5, 10011, 3, 2300),
(6, 10011, 3, 87820),
(7, 10012, 1, 345),
(8, 10012, 1, 190),
(9, 10012, 3, 5000),
(10, 10012, 3, 1500),
(11, 10012, 3, 7000)
GO
 
SELECT *
, MIN(Bal) OVER(PARTITION BY Acct,Months) MinimumBalance
, AVG(Bal*1.0) OVER(PARTITION BY Acct,Months) AverageBalance
, MAX(Bal) OVER(PARTITION BY Acct,Months) MaximumBalance
, FIRST_VALUE(Bal) OVER(PARTITION BY Acct,Months ORDER BY Id ASC) FirstValue
, FIRST_VALUE(Bal) OVER(PARTITION BY Acct,Months ORDER BY Id DESC) LastValue
FROM GetMinMaxAvgVal
ORDER By Id

/*
you have to check for each Id we have to count a, b, c and d values. If for each Id these values are not present then do not include them. For more details please check the sample input and expected output.

Sample Input

Id	Vals
1	a
1	b
1	c
1	d
2	a
2	d
3	d
4	g
Expected Output

Id	cnts
1	4
2	2
3	1
4	0
Script
*/

CREATE TABLE Table1
(
     Id VARCHAR(10) 
    ,Vals VARCHAR(10)
)
GO
  
INSERT INTO Table1 VALUES
(1, 'a'),
(1, 'b'),
(1, 'c'),
(1, 'd'),
(2, 'a'),
(2, 'd'),
(3, 'd')
GO
  
INSERT INTO Table1 VALUES (4,'g')
GO
 
SELECT * FROM Table1
GO
select Id,ISNULL(SUM(IIF(Vals IN ('a','b','c','d'),1,0)),0) CountVals 
FROM Table1
group by Id

/*
In this puzzle you have to check for each Id whether a, b, c and d values are present or not. If yes then you have output ‘Yes’ else ‘No’ for each a, b, c and d column. For more details please check the sample input and expected output.

Sample Input

Id	Vals
1	a
1	b
1	c
1	d
2	a
2	d
3	d
Expected Output

Id	a	b	c	d
1	Yes	Yes	Yes	Yes
2	Yes	No	No	Yes
3	No	No	No	Yes
Script
*/

CREATE TABLE Table1
(
     Id VARCHAR(10) 
    ,Vals VARCHAR(10)
)
GO
 
INSERT INTO Table1 VALUES
(1, 'a'),
(1, 'b'),
(1, 'c'),
(1, 'd'),
(2, 'a'),
(2, 'd'),
(3, 'd')
GO
 
SELECT * FROM Table1
GO
 
;WITH CTE AS
(
    SELECT * , 'Yes' Ya FROM Table1
)
SELECT Id, ISNULL([a],'No') [a],ISNULL([b],'No') [b],ISNULL([c],'No') [c],ISNULL([d],'No') [d] FROM CTE
PIVOT
(
    MAX(Ya) FOR Vals IN ([a],[b],[c],[d])
)t

/*
In this puzzle you have to club data from two table where data is different puzzle. For more details please check the sample input and expected output.

Sample Input

Table1

aId	val
1	a
2	b
3	c
4	d
Table2

aId	val
1	a
2	x
3	y
4	d
Expected Output

Id	val
2	b
3	c
2	x
3	y
Script
*/
CREATE TABLE testTable1
(
     aId INT
    ,val VARCHAR(1)
)
GO
 
INSERT INTO testTable1 VALUES
(1,'a'),
(2,'b'),
(3,'c'),
(4,'d')
GO
 
CREATE TABLE testTable2
(
     aId INT
    ,val VARCHAR(1)
)
GO
 
INSERT INTO testTable2 VALUES
(1,'a'),
(2,'x'),
(3,'y'),
(4,'d')
GO

SELECT ISNULL(a.aId,b.aId) Id, ISNULL(a.val,b.val) val 
FROM testTable1 a
FULL OUTER JOIN testTable2 b ON a.val = b.val
WHERE a.val IS NULL OR b.val IS NULL


/*
In this puzzle you have to find out Names of people with how many records they have inserted and how many records they have updated. For more details please check the sample input and expected output.

Sample Input

RId	InsertedBy	UpdatedBy
1	Pawan	Sharlee
2	Diwan	Naga
3	Kishan	Pawan
4	Chiku	Kishan
5	Avtaar	Sharlee
6	Ramesh	Pawan
7	Kapil	Vaibhav
8	Ishu	Avtaar
9	Avtaar	Sharlee
Expected Output

Nam	InsertedCount	UpdatedCount
Avtaar	2	1
Chiku	1	0
Diwan	1	0
Ishu	1	0
Kapil	1	0
Kishan	1	1
Naga	0	1
Pawan	1	2
Ramesh	1	0
Sharlee	0	3
Vaibhav	0	1
*/
 
CREATE TABLE LogData
(
     RId INT
    ,InsertedBy VARCHAR(30)
    ,UpdatedBy VARCHAR(30)
)
GO
 
INSERT INTO LogData VALUES
(1,'Pawan','Sharlee'),
(2,'Diwan','Naga'),
(3,'Kishan','Pawan'),
(4,'Chiku','Kishan'),
(5,'Avtaar','Sharlee'),
(6,'Ramesh','Pawan'),
(7,'Kapil','Vaibhav'),
(8,'Ishu','Avtaar'),
(9,'Avtaar','Sharlee')
GO
 
Select ISNULL(InsertedBy,UpdatedBy) Nam , ISNULL(i,0) Insertedcount , ISNULL(u,0) updatedcount from
(Select Insertedby ,Count(Insertedby) i   FROM
logdata Group by InsertedBy) a
FULL JOIN
(Select Updatedby ,Count(updatedby) u  FROM
logdata Group by updatedby)b on a.InsertedBy = b.UpdatedBy
/*
In this puzzle you have to generate the permutation in a sequence.For more details please check the sample input and expected output.

Sample Input

Id	ValueId	vname
1	1	A
2	2	B1
6	2	B2
3	3	C1
4	3	C2
5	3	C3
Expected Output

(No column name)
A-B1-C1
A-B1-C2
A-B1-C3
A-B2-C1
A-B2-C2
A-B2-C3
*/


 CREATE TABLE Permutation
(
   Id INT
  ,ValueId INT
  ,vname VARCHAR(10)
)
GO
 
INSERT INTO Permutation VALUES
(1,1,'A'),
(2,2,'B1'),
(6,2,'B2'),
(3,3,'C1'),
(4,3,'C2'),
(5,3,'C3')
GO

SELECT
    DISTINCT CONCAT(sc.vname,'-',sc1.vname,'-',sc2.vname) 
FROM Permutation sc 
INNER JOIN Permutation sc1 on sc1.ValueId > sc.ValueId
INNER JOIN Permutation sc2 on sc2.ValueId > sc1.ValueId

/*
In this puzzle you have to concatenate the columns Id, Nr and Code with ‘-‘ but only if the columns Value is NOT NULL. For more details please check the sample input and expected output.

Sample Input

Id	Nr	Code
a	a	a
a	a	NULL
a	NULL	NULL
a	a	b
NULL	NULL	b
NULL	a	b
NULL	NULL	NULL
Expected Output

Id	Nr	Code	Joined
a	a	a	a-a-a
a	a	NULL	a-a
a	NULL	NULL	a
a	a	b	a-a-b
NULL	NULL	b	b
NULL	a	b	a-b
NULL	NULL	NULL	
Script
*/
CREATE TABLE HandleNulls
(
   Id VARCHAR(10)
  ,Nr VARCHAR(10)
  ,Code VARCHAR(10)
)
GO
 
INSERT INTO HandleNulls VALUES
('a','a','a'  ),
('a','a' ,NULL ),
('a',NULL,NULL ),
('a','a' ,'b'  ),
(NULL,NULL,'b' ),
(NULL,'a','b'  ),
(NULL,NULL,NULL)
GO
 
SELECT *,CONCAT
    (
        Id,
            CASE WHEN Id IS NOT NULL AND Nr IS NOT NULL THEN CONCAT('-',Nr) ELSE Nr END
        ,   CASE WHEN Nr IS NOT NULL AND Code IS NOT NULL THEN CONCAT('-',Code) ELSE Code END
    )Joined
FROM HandleNulls

/*
In this puzzle you have to find out the extension of the file names present in a table. Note the file name may contain a .(dot) in its name. For more details please check the sample input and expected output.

Note – In T-SQL we do not have any function which will give us the last occurrence of any letter/string.

Sample Input

Id	fname
1	f1.xlsx
2	file2.doc
3	fl.h
4	testfile.abcxyz
5	t…est..file.abcxyz
Expected Output

fName	Extension
f1.xlsx	.xlsx
file2.doc	.doc
fl.h	.h
testfile.abcxyz	.abcxyz
t…est..file.abcxyz	.abcxyz
*/


 
SELECT * INTO FileNames1 FROM
    (
        SELECT 1 Id ,'f1.xlsx' fname UNION ALL
        SELECT 2,'file2.doc' fname  UNION ALL
        SELECT 3,'fl.h' fname   UNION ALL
        SELECT 4,'testfile.abcxyz' fname  UNION ALL
        SELECT 5,'t...est..file.abcxyz' fname  
    )z
 
 SELECT fName , '.'+REVERSE(SUBSTRING(REVERSE(FNAME),0,CHARINDEX('.', REVERSE(FNAME),0 ))) Extension FROM FileNames1
 
 /*
 In this puzzle we have accept a parameter called @departmentId and fetch data based on it with the total number of employees present in the department. If you get a @departmentId which is not present in the database then you need show count as 0 and other columns as NULL. We also need to add some static XML.Please check the sample input and expected output.

Sample Input

EmployeeID	LastName	FirstName	DepartmentID
1	Ramesh	k	1
2	Krishan	A	1
3	Avtaar	R	1
4	Harish	B	2
5	Naga	D	2
6	Simpson	M	3
7	Mayanka	J	5
Expected Output – 1 | Matching Data

cnt	EmployeeID	LastName	FirstName	DepartmentID
3	1	Ramesh	k	1
3	2	Krishan	A	1
3	3	Avtaar	R	1
Expected Output – 2 | NON – Matching Data

cnt	EmployeeID	LastName	FirstName	DepartmentID
0	NULL	NULL	NULL	NULL
Script
 */

 
 
CREATE TABLE [TestEmployees]
(
    [EmployeeID] [int] NOT NULL,
    [LastName] [Nvarchar](50) NULL,
    [FirstName] [varchar](50) NULL,
    [DepartmentID] [int] NULL
)
GO
     
INSERT [TestEmployees] ([EmployeeID], [LastName], [FirstName], [DepartmentID]) 
VALUES
 (1, 'Ramesh', N'k', 1)
,(2, 'Krishan', N'A', 1)
,(3, 'Avtaar', N'R', 1)
,(4, 'Harish', N'B', 2)
,(5, 'Naga', N'D', 2)
,(6, 'Simpson', N'M', 3)
,(7, 'Mayanka', N'J', 5)


DECLARE @DepartmentID AS INT = 1
 
SELECT * FROM
(
    SELECT
        COUNT([EmployeeID]) cnt
    FROM [TestEmployees]
    WHERE [DepartmentID] = @DepartmentID
)x 
LEFT JOIN
(
    SELECT
        *  
    FROM [TestEmployees]
    WHERE [DepartmentID] = @DepartmentID
)y ON 1 = 1
  
 /*
 we have to find people who failed the exam in last 3 attempts.Please check the sample input and expected output.

Sample Input

Dt	Name	Number	Result
2017-12-14 13:33:09.460	Pawan	1504579	pass
2017-12-14 13:33:12.460	Pawan	1504579	pass
2017-12-14 13:34:15.463	Pawan	1504579	pass
2017-12-14 13:36:18.470	Ramesh	1504579	fail
2017-12-14 13:37:21.470	Ramesh	1504579	pass
2017-12-14 13:37:24.473	Ramesh	1504579	fail
2017-12-14 13:38:27.473	vaibhav	1504579	fail
2017-12-14 13:38:40.473	vaibhav	1504579	fail
2017-12-14 13:38:40.473	vaibhav	1504579	fail
2017-12-14 13:38:49.477	vaibhav	1504579	pass
2017-12-14 13:38:51.477	K	1504579	fail
2017-12-14 13:39:02.477	K	1504579	fail
2017-12-14 13:39:11.480	mayank	1504579	pass
2017-12-14 13:39:18.480	mayank	1504579	fail
2017-12-14 13:39:21.480	mayank	1504579	fail
2017-12-14 13:39:24.480	mayank	1504579	fail
Expected Output

Name	Number	FailCount	Result
K	    1504579	    2	    Pass
mayank	1504579	    3	    Fail
Pawan	1504579	    0	    Pass
Ramesh	1504579	    2	    Pass
vaibhav	1504579	    2	    Pass
 
 */

 
 
CREATE TABLE testPassFail
(
  Dt DATETIME
 ,Name VARCHAR(20)
 ,Number BIGINT
 ,Result VARCHAR(4)
)
GO
 
INSERT INTO testPassFail VALUES (GETDATE(),'Pawan','1504579','pass');
WAITFOR DELAY '00:00:03';
INSERT INTO testPassFail VALUES (GETDATE(),'Pawan','1504579','pass');
WAITFOR DELAY '00:01:03';
INSERT INTO testPassFail VALUES (GETDATE(),'Pawan','1504579','pass');
WAITFOR DELAY '00:02:03';
INSERT INTO testPassFail VALUES (GETDATE(),'Ramesh','1504579','fail');
WAITFOR DELAY '00:01:03';
INSERT INTO testPassFail VALUES (GETDATE(),'Ramesh','1504579','pass');
WAITFOR DELAY '00:00:03';
INSERT INTO testPassFail VALUES (GETDATE(),'Ramesh','1504579','fail');
WAITFOR DELAY '00:01:03';
INSERT INTO testPassFail VALUES (GETDATE(),'vaibhav','1504579','fail');
WAITFOR DELAY '00:00:13';
INSERT INTO testPassFail VALUES (GETDATE(),'vaibhav','1504579','fail');
WAITFOR DELAY '00:00:00';
INSERT INTO testPassFail VALUES (GETDATE(),'vaibhav','1504579','fail');
WAITFOR DELAY '00:00:09';
INSERT INTO testPassFail VALUES (GETDATE(),'vaibhav','1504579','pass');
WAITFOR DELAY '00:00:02';
INSERT INTO testPassFail VALUES (GETDATE(),'K','1504579','fail');
WAITFOR DELAY '00:00:11';
INSERT INTO testPassFail VALUES (GETDATE(),'K','1504579','fail');
WAITFOR DELAY '00:00:09';
INSERT INTO testPassFail VALUES (GETDATE(),'mayank','1504579','pass');
WAITFOR DELAY '00:00:07';
INSERT INTO testPassFail VALUES (GETDATE(),'mayank','1504579','fail');
WAITFOR DELAY '00:00:03';
INSERT INTO testPassFail VALUES (GETDATE(),'mayank','1504579','fail');
WAITFOR DELAY '00:00:03';
INSERT INTO testPassFail VALUES (GETDATE(),'mayank','1504579','fail');
GO
 
SELECT * FROM testPassFail
 
SELECT k.Name,k.Number,SUM(CASE WHEN Result = 'Fail' THEN 1 ELSE 0 END) FailCount
,CASE WHEN SUM(CASE WHEN Result = 'Fail' THEN 1 ELSE 0 END) >= 3 THEN 'Fail' ELSE 'Pass' END Result 
FROM
(
    SELECT * , row_number()  OVER (PARTITION BY Name ORDER BY Dt desc) rk FROM testPassFail         
)k WHERE rk <= 3
GROUP BY k.Name,k.Number

/*
In this puzzle we have to find the duplicate data within 5 minutes of each other, the combination used for duplicate data is Individual ID and message text columns Please check the sample input and expected output.

Sample Input

SalesSiteID	MessageID	IndividualId	MessageText	DateAdded
103887	1	1	Pawan	2017-12-14 12:49:22.373
103887	2	1	Pawan	2017-12-14 12:49:24.373
103887	3	2	Sharlee	2017-12-14 12:49:34.377
103887	4	2	Sharlee	2017-12-14 12:50:36.377
103887	5	3	Ramesh	2017-12-14 12:50:39.380
103887	6	3	Ramesh	2017-12-14 12:50:39.380
103887	7	3	Ramesh	2017-12-14 12:51:19.380
103887	8	3	Ramesh	2017-12-14 13:01:21.380
103887	9	4	Avika	2017-12-14 13:03:23.383
103887	10	5	Panav	2017-12-14 13:03:23.387
Expected Output

MessageID	MessageID	IndividualID	MessageText	DateAdded	DateAdded
1	2	1	Pawan	2017-12-14 12:49:22.373	2017-12-14 12:49:24.373
3	4	2	Sharlee	2017-12-14 12:49:34.377	2017-12-14 12:50:36.377
5	6	3	Ramesh	2017-12-14 12:50:39.380	2017-12-14 12:50:39.380
5	7	3	Ramesh	2017-12-14 12:50:39.380	2017-12-14 12:51:19.380
6	7	3	Ramesh	2017-12-14 12:50:39.380	2017-12-14 12:51:19.380
Script
*/

CREATE TABLE DuplicateFiveMinutes
(
     SalesSiteID BIGINT
    ,MessageID BIGINT
    ,IndividualId BIGINT
    ,MessageText VARCHAR(200)
    ,DateAdded DATETIME
)
GO
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 1,1,'Pawan', GETDATE());
 
WAITFOR DELAY '00:00:02';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 2,1,'Pawan', GETDATE());
 
WAITFOR DELAY '00:00:10';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 3,2,'Sharlee', GETDATE());
 
WAITFOR DELAY '00:01:02';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 4,2,'Sharlee', GETDATE());
 
WAITFOR DELAY '00:00:03';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 5,3,'Ramesh', GETDATE());
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 6,3,'Ramesh', GETDATE());
 
WAITFOR DELAY '00:00:40';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 7,3,'Ramesh', GETDATE());
 
WAITFOR DELAY '00:10:02';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 8,3,'Ramesh', GETDATE());
 
WAITFOR DELAY '00:02:02';
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 9,4,'Avika', GETDATE());
 
INSERT INTO DuplicateFiveMinutes VALUES (103887, 10,5,'Panav', GETDATE());
 
WAITFOR DELAY '00:02:02';
 
SELECT m1.MessageID,
       m2.MessageID,
       m2.IndividualID ,
       m2.MessageText ,
       m1.DateAdded ,
       m2.DateAdded
FROM   DuplicateFiveMinutes m1
       INNER JOIN DuplicateFiveMinutes m2 ON m2.IndividualID = m1.IndividualID AND m2.MessageText = m1.MessageText
WHERE  m1.SalesSiteID = 103887
       AND m2.MessageID > m1.MessageID
       AND DATEDIFF(mi,m1.DateAdded,m2.DateAdded) <= 5  /* The time difference should be 5 mins*/
 
 /*
 we have seller and lister in the same row we have to separate them in two rows. Please check the sample input and expected output.

Sample Input

Seller	SellerID	Listing	ListingID	SoldPrice	Date
John	1	Bill	2	1900	2017-12-01
Jane	3	Becky	4	2400	2017-12-02
Joe	5	Jane	1	2100	2017-12-03
Expected Output

Seller	SoldPrice	Role	Date
John	1900	    Seller	2017-12-01
Jane	2400	    Seller	2017-12-02
Joe	2100	Seller	2017-12-03
Bill	    1900	Listing	2017-12-01
Becky	    2400	Listing	2017-12-02
Jane	    2100	Listing	2017-12-03

*/


CREATE TABLE Sellers
(
      Seller VARCHAR(20)
    , SellerID INT
    , Listing VARCHAR(20)
    , ListingID INT
    , SoldPrice INT
    , Date DATE
);
 
INSERT INTO Sellers VALUES ('John', 1, 'Bill', 2, 1900, '2017/12/01');
INSERT INTO Sellers VALUES ('Jane', 3, 'Becky', 4, 2400, '2017/12/02');
INSERT INTO Sellers VALUES ('Joe', 5, 'Jane', 1, 2100, '2017/12/03');
 
 
 
SELECT Seller,SoldPrice,'Seller'Role,Date
FROM Sellers
UNION ALL
SELECT Listing,SoldPrice,'Listing',Date
FROM Sellers;

/*
The Complex Hierarchy Puzzle [All Positions below – Line Manager]

In this puzzle we have to write a query that will give us the list of all Sr Line Staff or lower with their corresponding Line Manager. For details please refer the input data and the expected output.

Sample Input

Employees Table

EmployeeID	Name	ParentID	PositionID
1	Joe	4	1
2	Sue	5	5
3	John	6	7
4	Amy	7	2
5	Luis	10	6
6	Harry	8	8
7	Pete	9	3
8	Rhonda	10	9
9	Maria	10	4
10	Jack	NULL	10
11	Kate	12	5
12	Aaron	10	6
13	Julie	14	7
14	Sarah	15	8
15	Bob	10	9
Positions table

PositionID	Position	PositionTypeID
1	Operational Line Staff	1
2	Operational Team Lead	2
3	Operational Sr Line Staff	3
4	Operational Line Manager	4
5	Research Line Staff	1
6	Research Line Manager	4
7	Sales Staff	1
8	Sales Team Lead	2
9	Sales Manager	4
10	Branch Sr Manager	5
PositionTypes Table

PositionTypeID	PositionType
1	Line Staff
2	Team Lead
3	Sr Line Staff
4	Line Manager
5	Sr Line Manager
Expected Output

EmployeeID	Name	Position	Manager Name
1	Joe	    Operational Line Staff	Maria
2	Sue	    Research Line Staff	Luis
3	John	Sales Staff	Rhonda
4	Amy	    Operational Team Lead	Maria
6	Harry	Sales Team Lead	Rhonda
7	Pete	Operational Sr Line Staff	Maria
11	Kate	Research Line Staff	Aaron
13	Julie	Sales Staff	Bob
14	Sarah	Sales Team Lead	Bob
*/

CREATE TABLE tblPositionTypes    
(
     PositionTypeID INT
     ,PositionType VARCHAR(35)
)
GO
 
INSERT INTO tblPositionTypes VALUES
(1,'Line Staff'),
(2,'Team Lead'),
(3,'Sr Line Staff'),
(4,'Line Manager'),
(5,'Sr Line Manager')
GO
 
CREATE TABLE tblPositions        
(
     PositionID     INT
     ,Position VARCHAR(100)
     ,PositionTypeID INT
)
GO
 
INSERT INTO tblPositions VALUES
(1,'Operational Line Staff',1),
(2,'Operational Team Lead',2),
(3,'Operational Sr Line Staff',3),
(4,'Operational Line Manager',4),
(5,'Research Line Staff',  1),
(6,'Research Line Manager', 4),
(7,'Sales Staff',     1),
(8,'Sales Team Lead', 2),
(9,'Sales Manager',   4),
(10, 'Branch Sr Manager',  5)
GO
 
CREATE TABLE tblEmployees  
(
     EmployeeID     INT
     ,Name VARCHAR(10)
     ,ParentID  INT
     ,PositionID INT
)
GO
 
INSERT INTO tblEmployees VALUES      
(1   ,'Joe'     ,4   ,1         ),
(2   ,'Sue'     ,5   ,5         ),
(3   ,'John'    ,6   ,7         ),
(4   ,'Amy'     ,7   ,2         ),
(5   ,'Luis'    ,10  ,6         ),
(6   ,'Harry'   ,8   ,8   ),
(7   ,'Pete'    ,9   ,3         ),
(8   ,'Rhonda', 10,  9    ),
(9   ,'Maria'   ,10  ,4   ),
(10  ,'Jack'    ,NULL,     10   ),
(11  ,'Kate'    ,12  ,5         ),
(12  ,'Aaron'   ,10  ,6   ),
(13  ,'Julie'   ,14  ,7   ),
(14  ,'Sarah'   ,15  ,8   ),
(15  ,'Bob'     ,10  ,9         )
GO

 
;WITH CTE AS
(
     SELECT e.EmployeeID,e.Name,p.Position,e.ParentID FROM tblEmployees e
     INNER JOIN tblPositions    p ON e.PositionID = p.PositionID    
     INNER JOIN tblPositionTypes pt ON pt.PositionTypeID = p.PositionTypeID
     WHERE pt.PositionTypeID IN (1,2,3)    
)
,CTE1 AS
(
     SELECT e.EmployeeID,e.Position,e.Name,e.Name Name1,e.ParentID , 0 distance FROM CTE e
     UNION ALL
     SELECT * FROM
     (
           SELECT e.EmployeeID,e1.Position,e1.name,e.name name1,e.ParentID, e1.distance + 1 distance
           FROM CTE1 e1 INNER JOIN tblEmployees e ON e.EmployeeID = e1.ParentID 
     )k   
)
SELECT R.EmployeeID,R.Name,R.Position ,Q.Name1 [Manager Name] FROM
(
     SELECT * FROM CTE1 e 
     WHERE DISTANCE = 0
)r
CROSS APPLY
(
     SELECT * FROM CTE1 t
     WHERE t.Name = r.Name AND DISTANCE = ( SELECT MAX(DISTANCE) - 1 FROM CTE1 t WHERE t.Name = r.Name )
)q
ORDER BY r.EmployeeID 

/*Do not throw error if duplicate val inserted in primary key column*/
CREATE TABLE #tmp
(   
    Dates Date NULL,
    Cat [varchar](255) NULL,
    Plugin int PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = ON),
    IP Bigint NULL
)
GO
 
INSERT INTO #tmp VALUES
(GETDATE(),'1',1,1),
(GETDATE()+1,'2',2,1),
(GETDATE()+2,'3',3,1),
(GETDATE()+3,'4',1,1)
GO
 
SELECT * FROM #tmp
drop table #tmp

/*
Manager & Manager’s Manager Puzzle

You have to write a query that shows employee name, manager and the managers manager name. The catch is that you can only use Single SELECT statement only
to get the results

For details please check out the sample input and the expected output below-

Sample Inputs

EmpID	EmpName	ReportsTo
1	Jacob	NULL
2	Rui	NULL
3	Jacobson	NULL
4	Jess	1
5	Steve	1
6	Bob	1
7	Smith	2
8	Bobbey	2
9	Steffi	3
10	Bracha	3
11	John	5
12	Michael	6
13	Paul	6
14	Lana	7
15	Johnson	7
16	Mic	8
17	Stev	8
18	Paulson	9
19	Jessica	10
Expected Output

Employee	Manager	ManagersManager
Jacob	NULL	NULL
Rui	NULL	NULL
Jacobson	NULL	NULL
Jess	Jacob	NULL
Steve	Jacob	NULL
Bob	Jacob	NULL
Smith	Rui	NULL
Bobbey	Rui	NULL
Steffi	Jacobson	NULL
Bracha	Jacobson	NULL
John	Steve	Jacob
Michael	Bob	Jacob
Paul	Bob	Jacob
Lana	Smith	Rui
Johnson	Smith	Rui
Mic	Bobbey	Rui
Stev	Bobbey	Rui
Paulson	Steffi	Jacobson
Jessica	Bracha	Jacobson
*/

--Create Table
  
CREATE TABLE Employees  (EmpID INT, EmpName VARCHAR(20), ReportsTo INT)
  
--Insert Data
INSERT INTO Employees(EmpID, EmpName, ReportsTo)
SELECT 1, 'Jacob', NULL UNION ALL
SELECT 2, 'Rui', NULL UNION ALL
SELECT 3, 'Jacobson', NULL UNION ALL
SELECT 4, 'Jess', 1 UNION ALL
SELECT 5, 'Steve', 1 UNION ALL
SELECT 6, 'Bob', 1 UNION ALL
SELECT 7, 'Smith', 2 UNION ALL
SELECT 8, 'Bobbey', 2 UNION ALL
SELECT 9, 'Steffi', 3 UNION ALL
SELECT 10, 'Bracha', 3 UNION ALL
SELECT 11, 'John', 5 UNION ALL
SELECT 12, 'Michael', 6 UNION ALL
SELECT 13, 'Paul', 6 UNION ALL
SELECT 14, 'Lana', 7 UNION ALL
SELECT 15, 'Johnson', 7 UNION ALL
SELECT 16, 'Mic', 8 UNION ALL
SELECT 17, 'Stev', 8 UNION ALL
SELECT 18, 'Paulson', 9 UNION ALL
SELECT 19, 'Jessica', 10
  
--Verify Data
SELECT * FROM Employees E


 
SELECT E.EmpName, r.EmpName ManagerName, s.EmpName ManagersManager
FROM Employees E
OUTER APPLY
(
       SELECT TOP 1 m1.EmpName , m1.ReportsTo FROM Employees m1 WHERE m1.EmpId= E.ReportsTo
)r
OUTER APPLY
(
       SELECT TOP 1 m2.EmpName FROM Employees m2 WHERE m2.EmpId= r.ReportsTo
)s

SELECT E.EmpName, r.EmpName ManagerName, s.EmpName ManagersManager
FROM Employees E
LEFT JOIN Employees r ON r.EmpId= E.ReportsTo
LEFT JOIN Employees s ON s.EmpId= E.ReportsTo

/*
Update one table & Insert in another table using single T-SQL statement at same time

The requirement is whenever we update Val column from Updates table we need to insert an entry in the INSERTS table. The challenge is to do it in a single SQL statement.

For details please check out the sample input and the expected output below-

Sample Inputs

UPDATES table

ID	VAL
1	First
2	Second
Inserts table will be empty in the beginning.

Expected Output

E.g. We have updated val column for Id = 1 from ‘First’ to ‘Four’. After the operation the expected data in respective tables will be-

UPDATES table

ID	VAL
1	Four
2	Second
INSERTS Table

UpdatedAt	NewValue
8/17/2016 11:49	Four
*/

 
CREATE TABLE Updates
(
       ID TINYINT
       ,VAL VARCHAR(10)
)
GO
 
CREATE TABLE INSERTS
(
       UpdatedAt DATETIME
       ,NewValue  VARCHAR(10)     
)
GO
 
 
INSERT INTO Updates VALUES
(1,'First'),
(2,'Second')
GO
/*
** SOLUTION 1 
*/
 
INSERT INTO INSERTS
SELECT * FROM
(
  UPDATE a
  SET a.Val = 'Four' 
  OUTPUT GETDATE(),Inserted.Val FROM UPDATES a WHERE ID = 1
)t(a,b)
 
/*
** SOLUTION 2
*/
 
UPDATE  Updates 
SET VAL='Four'
OUTPUT GETDATE(), Inserted.Val INTO INSERTS 
WHERE ID = 1

/*
In the puzzle we have an input string and we have to find ASCII value for each character present in the string and position of each character in the string.

Please check out the sample input and the expected output below-

Sample Input

DECLARE @ VARCHAR(1000)= ‘KJhdsfmdsnfsd sdkfjsdk fjsd ‘

Expected Output

Position	Chr	AsciiChr
1	K	75
2	J	74
3	h	104
4	d	100
5	s	115
6	f	102
7	m	109
8	d	100
9	s	115
10	n	110
11	f	102
12	s	115
13	d	100
14		32
15	s	115
16	d	100
17	k	107
18	f	102
19	j	106
20	s	115
21	d	100
22	k	107
23		32
24	f	102
25	j	106
26	s	115
27	d	100
28		32
*/


 
 
DECLARE @ VARCHAR(1000)= 'KJhdsfmdsnfsd sdkfjsdk fjsd '
SELECT
        Number Position , SUBSTRING(@,Number,1) Chr, ASCII(SUBSTRING (@,Number,1)) AsciiChr
FROM
(
    SELECT
         DISTINCT Number 
    FROM
         Master..Spt_Values
    WHERE
         Number > 0 AND Number <= DATALENGTH(@)
)r

/*
The Maximum Consecutive Numbers puzzle

In this puzzle you need to find numbers with highest count of consecutive integers in a single column table. Like in below example-

Longest sequence of consecutive numbers in table could be 5,6,7,8 & 4 is the length of the longest sequence.

Other sequences are – 1,2,3 and the length is 3
– 12 and the length is 1

Hence we require output as starting Number of the sequence, ending number in the sequence and the length of the sequence.

Please check out the sample input values and sample expected output below.

Sample Input

id
1
2
3
5
6
7
8
12
Expected Output

MinId	MaxId	Cnts
5	8	4
*/

CREATE TABLE t
(
 id INT
)
 
insert into t values(7)
insert into t values(1)
insert into t values(2)
insert into t values(5)
insert into t values(6)
insert into t values(8)
insert into t values(12)
insert into t values(3)
GO
 
 
;WITH CTE1 AS
( 
       SELECT id , ROW_NUMBER() OVER (ORDER BY id) Rnk FROM t 
)
,CTE2 AS
(
       SELECT *,  CASE WHEN Id-1 = LAG(Id) OVER(ORDER BY rnk) THEN 0 ELSE 1 END cols FROM CTE1 c2
)
,CTE3 AS
(
       SELECT *,  SUM(cols) OVER(ORDER BY rnk) Grouper FROM CTE2 c2
)
SELECT TOP 1 * FROM
(
    SELECT MIN(Id) MinId, MAX(Id) MaxId , COUNT(*) Counts FROM CTE3 GROUP BY Grouper
)r
ORDER BY Counts DESC
--Sol 2
;WITH CTE1 AS
( 
       SELECT id , id - ROW_NUMBER() OVER (ORDER BY id) Rnk FROM t 
)
SELECT TOP 1 *
FROM
(
    SELECT MIN(Id) MinId, MAX(Id) MaxId ,COUNT(*) Cnts FROM CTE1
    GROUP BY Rnk
)t
ORDER BY Cnts DESC

/*
Break Table in Equal Parts

In this puzzle you have to break the table in equal parts. Let’s say you have 14 rows in the table and the ask was to break the table in 3 equal parts – of course in the first 2 parts we will have 5 rows and in the last part we will have 4 rows.

Please check out the sample input values and sample expected output below.

Sample Input

EmpId	EmpName	Salary
1	        a	1000
2	        b	900
3	        c	100
4	        d	1100
5	        e	1300
6	        f	700
7	        g	330
8	        h	800
9	        i	500
10	        j	340
11	        k	600
12	        l	700
13	        m	1000
14	        n	1800
Expected Output

Grouper	EmpSalaryRanges	Counts
1	    100-600	        5
2	    700-1000	    5
3	    1000-1800	    4
*/


 
 
CREATE TABLE EmpRangers
(
     EmpId INT
    ,EmpName VARCHAR(10)
    ,Salary INT
)
GO
 
INSERT INTO EmpRangers
VALUES
(1,'a',1000),
(2,'b',900),
(3,'c',100),
(4,'d',1100),
(5,'e',1300),
(6,'f',700),
(7,'g',330),
(8,'h',800),
(9,'i',500),
(10,'j',340),
(11,'k',600),
(12,'l',700),
(13,'m',1000)
GO
 
INSERT INTO EmpRangers
VALUES
(14,'n',1800)
GO

 
;WITH CTE AS
(
    SELECT
             Salary
            ,NTILE(3) OVER (ORDER BY Salary) Grouper
    FROM
            EmpRangers
)
SELECT Grouper, CONCAT(MIN(Salary),'-',MAX(Salary)) EmpSalaryRanges, COUNT(*) Counts
FROM CTE
GROUP BY Grouper

/*
Fetch 2 records from each salary bracket

This is a good puzzle from interview stand point. In the puzzle you to break down salary data into below brackets & from each bracket return 2 records.

0-999
1000-1999
2000-2999
3000+

Please check out the sample input values and sample expected output below.

Sample Input

EmpId	EmpName	Salary
1	    Pawan	1000
2	    Ramesh	1100
3	    Krishna	200
4	    Sharlee	219
5	    Isha	2000
6	    Honey	576
7	    Avika	7000
8	    Mayank	8000
9	    Pushpa	19000
Expected Output

EmpId	EmpName	Salary
3	    Krishna	200
4	    Sharlee	219
1	    Pawan	1000
2	    Ramesh	1100
5	    Isha	2000
7	    Avika	7000
8	    Mayank	8000
*/


 
CREATE TABLE RangeEmployees
(
 
     EmpId SMALLINT PRIMARY KEY
    ,EmpName VARCHAR(10)
    ,Salary INT
)
GO
 
INSERT INTO RangeEmployees VALUES
(1,'Pawan',1000),
(2,'Ramesh',1100),
(3,'Krishna',200),
(4,'Sharlee',219),
(5,'Isha',2000),
(6,'Honey',576),
(7,'Avika',7000),
(8,'Mayank',8000),
(9,'Pushpa',19000)
GO
 
/*
**  Solution 1
*/
 
SELECT A.* FROM
(VALUES (0,999), (1000,1999), (2000,2999), (3000,2147483647)) AS t(a,b)
CROSS APPLY
(
       SELECT TOP 2 EmpId,EmpName,Salary FROM rangeemployees R where r.salary BETWEEN t.a AND t.b
)A
GO
 
  
/*
**  Solution 2
*/
 
SELECT TOP 2 * 
       FROM RangeEmployees 
       WHERE Salary between 0 and 999 
UNION ALL
       SELECT TOP 2 * 
       FROM RangeEmployees
       WHERE Salary between 1000 and 1999
UNION ALL
       SELECT TOP 2 * 
       FROM RangeEmployees
       WHERE Salary between 2000 and 2999 
UNION ALL
       SELECT TOP 2 * 
       FROM RangeEmployees
       WHERE Salary >= 3000
  /*
  Calculate 2nd Highest & 2nd Lowest Salary / Nth Highest and Nth Lowest Salary at the same time

This question was asked to me in one of the technical interviews I had recently attended. Here we have to find out Nth Highest and Nth Lowest Salary at the same time. So effectively we will have 2 rows.

Please check out the sample input values and sample expected output below.

Sample Input

ID	EmpName	Salary
1	P	100
2	Q	500
3	R	230
4	S	1000
5	L	670
Expected Output

ID	EmpName	Salary
3	R	230
5	L	670

*/


 
CREATE TABLE testEmp
(
     ID SMALLINT
    ,EmpName VARCHAR(1)
    ,Salary INT
)
GO
 
INSERT INTO testEmp VALUES
(1, 'P',    100 ),
(2, 'Q',    500 ),
(3, 'R',    230 ),
(4, 'S',    1000 ),
(5, 'L',    670 )
GO
 
DECLARE @NthHighestLowest AS INT = 2
 
SELECT ID,EmpName,Salary FROM
(
    SELECT
        ID,EmpName,Salary
        ,ROW_NUMBER() OVER (ORDER BY Salary ASC) r1
        ,ROW_NUMBER() OVER (ORDER BY Salary DESC) r2
    FROM testEmp
)x WHERE r1 = @NthHighestLowest OR r2 = @NthHighestLowest
ORDER BY r1
--Sol 2
SELECT ID,EmpName,Salary FROM testEmp e1
WHERE  (@NthHighestLowest-1) = (SELECT DISTINCT COUNT(*) FROM testEmp e2 WHERE e2.Salary > e1.Salary )
    OR (@NthHighestLowest-1) = (SELECT DISTINCT COUNT(*) FROM testEmp e2 WHERE e2.Salary < e1.Salary )    
      
/*
Count different type of characters from a string Puzzle

This question was asked to me in one of the technical interviews I had attended. Here you have an input string and you have count uppercase characters , lowercase characters and remaining characters from a string.

Please check out the sample input values and sample expected output below.

Sample Input

DECLARE @ AS VARCHAR(1000) = ‘AddsfsdfWUES 12*&’

Expected Output

UpperCaseCount	LowerCaseCount	OtherChrCount
5	7	5
*/


 
DECLARE @ AS VARCHAR(1000) = 'AddsfsdfWUES 12*&'
 
SELECT 
        SUM(CASE WHEN ASCII(chr) BETWEEN 65 AND 90 THEN 1 ELSE 0 END) UpperCaseCount
       ,SUM(CASE WHEN ASCII(chr) BETWEEN 97 AND 122 THEN 1 ELSE 0 END) LowerCaseCount
       ,SUM(CASE WHEN (( ASCII(chr) NOT BETWEEN 97 AND 122 ) AND ( ASCII(chr) NOT BETWEEN 65 AND 90 )) THEN 1 ELSE 0 END) OtherChrCount 
FROM
(
    SELECT DISTINCT Number , SUBSTRING(@,Number,1) chr
    FROM Master..spt_Values 
    WHERE Number > 0 and number <= LEN(@)
)p  

/*
Get Last 4 Characters from a String without Left & Right Function

This question was asked to me in one of the technical interviews I had recently attended. The puzzle is like you have to get last 10 characters from a string and you cannot use LEFT and RIGHT inbuilt functions.

Please check out the sample input values and sample expected output below.

Sample Input

Sample input : 123____ [123 & the 4 spaces are there]

Expected Output

Expected Output will be : ____ [4 spaces]
*/

 
DECLARE @ AS VARCHAR(1000) = '123    '
 
SELECT RIGHT(@,4) Last4Characters
 
SELECT REVERSE(LEFT(REVERSE(@),4)) Last4Characters
 
SELECT SUBSTRING(@,DATALENGTH(@) - 4 + 1 ,DATALENGTH(@)) Last4Characters
 
/*
Split & Count Puzzle

Puzzle Statement

The puzzle is simple. You have to split the data based on semi colon. This question was asked at an online forum. Well there are many methods to split data. I am here using simple XML method. You cannot use a loop or cursor. Please check input and expected output for details.

Sample Input

cols
Ted;Joe;Mike
Ted;Joe
Ted
Expected output

SplittedString	Counts
Joe	2
Mike	1
Ted	3
*/


 
CREATE TABLE SplitAndCount
(
    cols VARCHAR(100)
)
GO
 
INSERT INTO SplitAndCount (cols)
VALUES ('Ted;Joe;Mike'),('Ted;Joe'),('Ted')
GO
 
 
SELECT SplittedString , COUNT(*) Counts FROM
(
    SELECT  CAST(CONCAT('<A>' , REPLACE(cols, ';' , '</A><A>' ) , '</A>' ) AS XML) Xmlcol FROM SplitAndCount
) s
CROSS apply
(
    SELECT ProjectData.D.value('.', 'VARCHAR(4)') as SplittedString
    FROM s.xmlcol.nodes('A') as ProjectData(D)
)a
GROUP BY a.SplittedString


/*SIMPLE PIVOT EXAMPLE 

Sample Input

Country_cost
12.09
23.09
34.76
23.65
456.098
Expected output

A_Cost	B_Cost	C_Cost	D_Cost	E_Cost
12.09	23.09	34.76	23.65	456.098*/


 
CREATE TABLE CountryCost
(
    Country_cost FLOAT
)
GO
 
INSERT INTO CountryCost(Country_cost) 
VALUES (12.09),(23.09),(34.76),(23.65),(456.098)
GO
 
;WITH CTE AS
(
    SELECT Country_cost , ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) rnk FROM CountryCost
)
SELECT [1] A_Cost , [2] B_Cost , [3] C_Cost , [4] D_Cost, [5] E_Cost FROM
CTE 
PIVOT (MAX(Country_cost) FOR rnk IN ([1],[2],[3],[4],[5])) p
 

 /*Display version history by version order*/
 
 
CREATE TABLE VersionHistory
(
    VersionHistory VARCHAR(10)
)
GO
 
insert into VersionHistory values ('1.1')
insert into VersionHistory values ('1.1.1')
insert into VersionHistory values ('1.2.10')
insert into VersionHistory values ('1')
insert into VersionHistory values ('1.10.1')
insert into VersionHistory values ('1.1.2')
insert into VersionHistory values ('2.1')
insert into VersionHistory values ('2')
insert into VersionHistory values ('1.10.2')
insert into VersionHistory values ('1.2')
insert into VersionHistory values ('1.2.4')
insert into VersionHistory values ('1.2.5')
 
GO
 

;WITH CTE AS
(
    SELECT VersionHistory, CAST(CONCAT('<A>',REPLACE(VersionHistory,'.','</A><A>'),'</A>') AS XML) Xmlcol 
    , ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) rnk 
    FROM VersionHistory
)
,CTE1 AS
(
    SELECT VersionHistory, SplittedString , rnk , ROW_NUMBER() OVER (PARTITION BY RNK ORDER BY (SELECT NULL)) finalrnk 
    FROM
        (SELECT * FROM CTE) s
    CROSS APPLY
        (
            SELECT ProjectData.D.value('.', 'SMALLINT') as SplittedString
            FROM s.xmlcol.nodes('A') as ProjectData(D)
        ) a
)
SELECT VersionHistory FROM CTE1
PIVOT ( MAX(SplittedString) FOR finalrnk IN ([1],[2],[3]) ) pvt
ORDER BY [1],[2],[3]

SELECT VersionHistory FROM VersionHistory
ORDER BY CAST('/'+REPLACE(VersionHistory,'.','/')+'/' AS HIERARCHYID)
 

/*
Multiplication of Digits Puzzle

Puzzle Statement

In this puzzle you have to find multiplication of digits from an input number/string

Sample Input

Sample Input could be for example – 912 or ‘W912W’

Expected output

Multiplication Of Digits in this case is 18
*/


 
--Trial # 1st Trial
DECLARE @str AS VARCHAR(100) = '912'
  
;WITH CTE AS
(
      SELECT  1 start , CASE WHEN SUBSTRING(@str,1,1) LIKE '[0-9]' THEN CAST(SUBSTRING(@str,1,1) AS TINYINT) ELSE 0 
                END MultiplicationOutput
      UNION ALL
      SELECT  start + 1 start 
              , MultiplicationOutput * CASE WHEN SUBSTRING(@str,start+1,1) LIKE '[0-9]' THEN CAST(SUBSTRING(@str,start+1,1) AS TINYINT) ELSE 0 
                END MultiplicationOutput
      FROM CTE WHERE start < DATALENGTH(@str)
)
SELECT MAX(MultiplicationOutput) MultiplicationOutput FROM CTE
 
--#- 2nd Trial
DECLARE @str AS VARCHAR(100) = 'W912W'
  
;WITH CTE AS
(
      SELECT  1 start , CASE WHEN SUBSTRING(@str,1,1) LIKE '[0-9]' THEN CAST(SUBSTRING(@str,1,1) AS TINYINT) ELSE 1
                END MultiplicationOutput
      UNION ALL
      SELECT  start + 1 start 
              , MultiplicationOutput * CASE WHEN SUBSTRING(@str,start+1,1) LIKE '[0-9]' THEN CAST(SUBSTRING(@str,start+1,1) AS TINYINT) ELSE 0 
                END MultiplicationOutput
      FROM CTE WHERE start < DATALENGTH(@str)
)
SELECT MAX(MultiplicationOutput) MultiplicationOutput FROM CTE

/*
Sum of Digits Puzzle

Puzzle Statement

In this puzzle you have to find sum digits from an input number/string

Sample Input

Sample Input could be for example – 100992 or ‘1WW992’

Expected output

Sum Of Digits in this case is 21
*/
--sol 1 using numebrs table

DECLARE @intValue AS VARCHAR(10) = 100992

SELECT SUM(CAST(SUBSTRING(@intValue,number,1) AS TINYINT)) SUMOFDIGITS FROM ( 
SELECT DISTINCT number FROM
MASTER..SPT_VALUES WHERE number > 0 AND number <= DATALENGTH(@intValue) ) x
--sol  2 char validation

DECLARE @intValue AS VARCHAR(10) = '1WW992'
 
SELECT SUM( CASE WHEN SUBSTRING(@intValue,number,1) LIKE '[0-9]' THEN CAST(SUBSTRING(@intValue,number,1) AS TINYINT) ELSE 0 END ) 
SUMOFDIGITS FROM
( 
  SELECT DISTINCT number FROM
  MASTER..SPT_VALUES WHERE number > 0 AND number <= DATALENGTH(@intValue) 
) x

/*
Convert a string into a table without any delimiter

Puzzle Statement

You have an input string and you have create a table from it. Each character will be converted in a row with a single column. Check out sample input and expected output.

Sample Input

STRING = ‘sdgfhsdgfhs@121313131’

Expected output

OutputChrs
s
d
g
f
h
s
d
g
f
h
s
@
1
2
1
3
1
3
1
3
1
*/
--using while
 
DECLARE @Counter AS INT = 1
DECLARE @Chrs TABLE (OutputChrs Char(1))
 
WHILE (@Counter <= DATALENGTH(@str)) 
BEGIN
    INSERT INTO @Chrs VALUES
    (    
        SUBSTRING(@str,@Counter,1)  
    ) 
    SET @Counter = @Counter + 1 
END
SELECT OutputChrs FROM @Chrs

-- RECURSIVE CTE
 
DECLARE @str AS VARCHAR(100) = 'sdgfhsdgfhs@121313131'
 
;WITH CTE AS
(
      SELECT  1 start , SUBSTRING(@str,1,1) OutputChrs
      UNION ALL
      SELECT  start + 1 start , SUBSTRING(@str , start+1 , 1) OutputChrs
      FROM CTE WHERE start < DATALENGTH(@str)
)
SELECT OutputChrs FROM CTE

--using select from numbers table
 
DECLARE @str AS VARCHAR(100) = 'sdgfhsdgfhs@121313131'
 
SELECT SUBSTRING(@str,number,1) OutputChrs FROM ( 
SELECT DISTINCT number FROM
MASTER..SPT_VALUES WHERE number > 0 AND number <= DATALENGTH(@str) ) x
 

/*
splt string and insert into same column
*/


 
SELECT ID, SplittedString FROM
(
    SELECT  ID, CAST('<A>'+ REPLACE(Value,',','</A><A>')+ '</A>' AS XML) Xmlcol FROM SplitString2
) s
CROSS apply
(
    SELECT ProjectData.D.value('.', 'VARCHAR(5)') as SplittedString
    FROM s.xmlcol.nodes('A') as ProjectData(D)
)a

/*
There was a question on facebook about pivoting data. Its very easy you just have to pivot data based on the empid and punchadate cities. Let’s go through the sample input and expected output below-
Sample Input
empid	punchdate	punchtime
1	01-Aug	10:00:00
1	01-Aug	12:00:00
1	01-Aug	15:00:00
1	01-Aug	18:00:00
1	01-Aug	22:00:00
2	01-Aug	10:00:00
2	01-Aug	12:00:00
2	01-Aug	15:00:00
1	02-Aug	09:00:00
1	02-Aug	11:00:00
1	02-Aug	15:00:00
2	02-Aug	07:00:00
2	02-Aug	08:00:00
2	02-Aug	09:00:00
2	02-Aug	12:00:00
2	02-Aug	15:00:00
Expected Output

empid	punchdate	1	2	3	4	5
1	01-Aug	10:00:00	12:00:00	15:00:00	18:00:00	22:00:00
2	01-Aug	10:00:00	12:00:00	15:00:00	NULL	NULL
1	02-Aug	09:00:00	11:00:00	15:00:00	NULL	NULL
2	02-Aug	07:00:00	08:00:00	09:00:00	12:00:00	15:00:00
*/

CREATE TABLE Punch
(
empid INT
,punchdate VARCHAR(3)
,punchtime TIME(5)
)
GO
 
INSERT INTO Punch(empid,punchdate,punchtime) VALUES
(1, '1/8','10:00'),
(1, '1/8','12:00'),
(1, '1/8','15:00'),
(1, '1/8','18:00'),
(1, '1/8','22:00'),
(2, '1/8','10:00'),
(2, '1/8','12:00'),
(2, '1/8','15:00'),
(1, '2/8','09:00'),
(1, '2/8','11:00'),
(1, '2/8','15:00'),
(2, '2/8','07:00'),
(2, '2/8','08:00'),
(2, '2/8','09:00'),
(2, '2/8','12:00'),
(2, '2/8','15:00')
GO

WITH CTE AS
(
SELECT * , ROW_NUMBER() OVER (PARTITION BY empid,Punchdate ORDER BY (SELECT NULL)) rnk
FROM Punch
)
SELECT empid,punchdate,[1],[2],[3],[4],[5]
FROM CTE
PIVOT (MAX(punchtime) FOR rnk IN ([1],[2],[3],[4],[5])) p

/*

There was a question Its very easy you just have to remove the nulls from the different cities. Check out the input and expected output below-
Sample Input

ID	Name	Salary	City1	City2	City3
1	A	100	Bangalore	NULL	NULL
1	B	200	NULL	Pune	NULL
1	C	300	NULL	NULL	Hyderabad
Expected Output

Id	Name	Salary	City1	City2	City3
1	A	100	Bangalore	Pune	Hyderabad
*/


 
CREATE TABLE RemoveNulls
(
     ID INT
    ,Name VARCHAR(1)
    ,Salary INT
    ,City1 VARCHAR(50)
    ,City2 VARCHAR(50)
    ,City3 VARCHAR(50)
)
GO
 
INSERT INTO RemoveNulls(ID,Name,Salary,City1,City2,City3)
VALUES
(1,'A',100,'Bangalore',NULL,NULL),(1,'B',200,NULL,'Pune',NULL),(1,'C',300,NULL,NULL,'Hyderabad')
GO
 
CREATE CLUSTERED INDEX Ix_Id ON RemoveNulls(Id)
GO


 
--Solution1
SELECT *
, ( SELECT TOP 1 City2  FROM RemoveNulls r1 WHERE r1.City2 IS NOT NULL AND r1.ID = X.ID ) City2
, ( SELECT TOP 1 City3  FROM RemoveNulls r1 WHERE r1.City3 IS NOT NULL AND r1.ID = X.ID ) City3
FROM
(
    SELECT r.ID,MIN(Name) Name,MIN(Salary) Salary ,MIN(City1) City1
    FROM RemoveNulls r
    WHERE City1 IS NOT NULL
    GROUP BY ID
)X
 
--Solution 2
SELECT
          Id
        , MIN(name) Name
        , MIN(Salary) Salary
        , MAX(city1) City1
                , MAX(city2) City2
        , MAX(city3) City3
FROM RemoveNulls GROUP BY id

/*Change 0 to 1 1 to 0*/

 
CREATE TABLE ZeroOne
(
Id INT
)
GO
 
INSERT INTO ZeroOne VALUES (0),(1),(0),(1),(0),(0)

 
SELECT *, CASE ID WHEN 0 THEN 1 ELSE 0 END Ids FROM ZeroOne
 
SELECT *, (Id - 1) * -1 Ids FROM ZeroOne
 
SELECT *, 1 - Id Ids FROM ZeroOne
 
SELECT *, IIF(ID=0,1,0) Ids FROM ZeroOne
 
SELECT Id, (Id+1/2 -1) * -1 Ids FROM ZeroOne
 
DECLARE @t AS INT = 1
SELECT Id, CHOOSE(@t,1,0) Ids FROM ZeroOne

/*
Tree Heirarchy
We have a table called Hierarchies, here we have two columns named ParentID and ChildID. Each ChildID can appear again in this table as a Parent, with other children. Its like a tree structure.
Please check out the sample input and expected output for details.
Sample Input

ParentID	ChildID
1	2
2	3
3	4
Expected Output

ParentID	ChildID
1	2
1	3
1	4
2	3
2	4
3	4
*/

CREATE TABLE Hierarchies
(
      ParentID INT
    , ChildID INT
)
GO
 
INSERT Hierarchies VALUES (1,2)
INSERT Hierarchies VALUES (2,3)
INSERT Hierarchies VALUES (3,4)

 
;WITH CTE1 AS
(
    SELECT ParentID , ChildID FROM Hierarchies
    UNION ALL
    SELECT c.ParentID , H.ChildID FROM CTE1 c INNER JOIN Hierarchies H
    ON H.ParentID = c.ChildID 
)
SELECT * FROM CTE1 ORDER BY ParentID

/*fizzbuzz*/
SELECT DISTINCT number,
    CASE WHEN CAST(number AS VARCHAR(3)) % 15 = 0 THEN 'FIZZBUZZ'
         WHEN CAST(number AS VARCHAR(3)) % 3 = 0 THEN 'FIZZ'
         WHEN CAST(number AS VARCHAR(3)) % 5 = 0 THEN 'BUZZ'
    ELSE
        CAST(number AS VARCHAR(3))
    END Outputs
FROM master..spt_values WHERE number BETWEEN 1 AND 100 ORDER BY number
 
/*
Puzzle Statement

The puzzle is simple.
You have to list out student information where the student scored more than the Average Marks per subject.
Please check out the sample input and expected output for details.
Sample Input

Sname	SMarks	SSubject
A	    10	    X
B	    20	    X
C	    30	    Y
D	    40	    Y
Expected Output

Sname	SMarks	SSubject
B	20	X
D	40	Y
*/
CREATE TABLE Neeraj
(
       Sname VARCHAR(1)
       ,SMarks INT
       ,SSubject VARCHAR(1) 
)
GO
 
INSERT INTO Neeraj(Sname, SMarks , SSubject) VALUES
('A'   ,       10   ,  'X'),
('B'   ,         20  , 'X'),
('C'   ,         30  ,  'Y'),
('D',     40  ,  'Y')

 
/************   SOLUTION 1         ****************/
 
SELECT n.*, Ag FROM Neeraj n
INNER JOIN (
SELECT AVG(SMarks) Ag , SSubject FROM Neeraj GROUP BY SSubject ) a on a.SSubject = n.SSubject
WHERE SMarks > Ag
 
 
 
/************   SOLUTION 2        ****************/
 
SELECT * 
FROM Neeraj n 
WHERE SMarks > ( SELECT AVG(SMarks) ag FROM Neeraj n1 WHERE n1.SSubject = n.SSubject GROUP BY SSubject ) 
 

/*
We have a table named Orders1 , dates and parts.
You have join all these tables and return part information , date and count.
Count is how many orders we have for this partid on this idate
For details please check out the sample input and expected output

Parts

partid
1
2
Dates

idate
01-01-2008
02-01-2008
Orders1 Table

partid	idate
1	01-01-2008
1	02-01-2008
2	01-01-2008
Expected Output

partid	idate	counts
1	01-01-2008	1
1	02-01-2008	1
2	01-01-2008	1
2	02-01-2008	0
*/

create table Dates1(idate datetime)
insert into Dates1 select '1/1/2008'
insert into Dates1 select '1/2/2008'
 
create table parts(partid int)
insert into parts select 1
insert into parts select 2
 
create table orders1(partid int,idate datetime)
insert into orders1 select 1,'1/1/2008'
insert into orders1 select 1,'1/2/2008'
insert into orders1 select 2,'1/1/2008'


 
/************   SOLUTION 1    | Deepak Sharma     ****************/
 
 
 
SELECT p.partid,d.idate,  COUNT(o.idate) Counts FROM parts p cross join Dates1 d left join orders1 o ON d.idate = o.idate and p.partid = o.partid
GROUP BY p.partid, d.idate ORDER BY 1
 
 
/************   SOLUTION 2    | Pawan Kumar Khowal     ****************/
 
SELECT p.partid, d.idate,COUNT(o.partid) OVER (PARTITION BY o.partid , o.idate ORDER BY (SELECT NULL)) counts FROM orders1 o
FULL OUTER JOIN Dates1 d CROSS JOIN parts p ON d.idate = o.idate AND p.partid = o.partid
ORDER BY p.partid

/*
[ The Multiple Condition Puzzle ]

Puzzle Statement

We have a table called “Groups”
I need to pick the group_no’s who has group_name both TEST1 and TEST2 and Active should be 1. In this case I need 100 and 300 as this both group_no contains TEST1 and TEST2 and are active.
Here i don’t get 200 because it has both groupnames but for the 4th record its active status is 0.
Here i dont get 400 because it has only TEST1 but dont have a record with groupname TEST2.
Please check out the sample input and expected output for details.
Sample Input

Group_id	Group_no	Group_name	Active
1	100	TEST1	1
2	100	TEST2	1
3	200	TEST1	1
4	200	TEST2	0
5	300	TEST1	1
6	300	TEST2	1
7	400	TEST1	1
Expected output

Group_id	Group_no	Group_name	Active
1	100	TEST1	1
2	100	TEST2	1
5	300	TEST1	1
6	300	TEST2	1
*/


 
CREATE TABLE Groups
(
     Group_id INT
    ,Group_no INT
    ,Group_name VARCHAR(10)
    ,Active INT
)
GO
 
INSERT INTO Groups VALUES
(1, 100, 'TEST1', 1),
(2, 100, 'TEST2', 1),
(3, 200, 'TEST1', 1),
(4, 200, 'TEST2', 0),
(5, 300, 'TEST1', 1),
(6, 300, 'TEST2', 1),
(7, 400, 'TEST1', 1)

;WITH CTE1 AS
(
    SELECT Group_no FROM Groups WHERE Active = 1 AND Group_name = 'TEST1'
)
, CTE2 AS
(
    SELECT Group_no FROM Groups WHERE Active = 1 AND Group_name = 'TEST2'
)
SELECT * FROM CTE1 a
INNER JOIN CTE2 b ON a.Group_no = b.Group_no
INNER JOIN Groups g on a.Group_no = g.Group_no


/*
The puzzle is very simple. Here you have to swap values of column. In sample input case you have only column called Val. In this column only 2 values are present ‘A’ & ‘B’. We have to update value of A with B and B with A. Please check out the sample input and expected output for details.

Sample Input

Val
A
B
B
A
B
B
Expected output

Val
B
A
A
B
A
A
*/

CREATE TABLE Swap
(
Val VARCHAR(1)
)
GO
 
INSERT INTO Swap(Val) VALUES ('A'),('B'),('B'),('A'),('B'),('B')
 
 
UPDATE s
SET s.Val = s1.Val
FROM Swap S
INNER JOIN Swap S1
ON S.Val <> S1.Val

/*
Here we have to find out employees from  the input table with their manager and dept. Please check out the sample input and expected output for details.

Sample Input

Id	Name	Dept	Manager
101	Ranjan	SW	
102	Deeksha	SW	101
103	sham	SW	101
104	Junaid	SW	101
105	Vinay	HQ	
106	akhilesh	HQ	105
107	Pranav	HQ	105
Expected output

Name	DeptNm	MgrNm
akhilesh	HQ	Vinay
Pranav		
Deeksha	SW	Ranjan
sham		
Junaid
*/


 
CREATE TABLE Complex
(Id INT, Name VARCHAR(50), Dept VARCHAR(50), Manager VARCHAR(50))
 
INSERT INTO Complex VALUES (101,'Ranjan','SW','')
INSERT INTO Complex VALUES (102,'Deeksha','SW','101')
INSERT INTO Complex VALUES (103,'sham','SW','101')
INSERT INTO Complex VALUES (104,'Junaid','SW','101')
INSERT INTO Complex VALUES (105,'Vinay','HQ','')
INSERT INTO Complex VALUES (106,'akhilesh','HQ','105')
INSERT INTO Complex VALUES (107,'Pranav','HQ','105')
 
 
SELECT p.Name,CASE WHEN rnk > 1 THEN '' ELSE DeptName END DeptNm, CASE WHEN rnk > 1 THEN '' ELSE MgrName END MgrNm
FROM
(
      SELECT c.Dept DeptName ,c.Name MgrName , c2.Name , c2.Id  , ROW_NUMBER() OVER (PARTITION BY c.Dept ORDER BY c.Dept ) rnk FROM Complex c
      INNER JOIN Complex c2 ON c.Id = c2.Manager
) P



/*
[ Print Male and Female Alternate Puzzle ]  – In this puzzle we have print male and female alternate from the sample input table. Please check out the sample input and expected output for details.

Sample Input

ID	NAME	GENDER
1	Neeraj	M
2	Mayank	M
3	Pawan	M
4	Gopal	M
5	Sandeep	M
6	Isha	F
7	Sugandha	F
8	kritika	F
Expected Output

ID	NAME	GENDER
1	Neeraj	M
6	Isha	F
2	Mayank	M
7	Sugandha	F
3	Pawan	M
8	kritika	F
4	Gopal	M

5	Sandeep	M
*/
CREATE TABLE dbo.AlternateMaleFemale
(
ID INT
,NAME VARCHAR(10)
,GENDER VARCHAR(1)
)
GO
 
--Insert data
INSERT INTO dbo.AlternateMaleFemale(ID,NAME,GENDER)
VALUES
(1,'Neeraj','M'),
(2,'Mayank','M'),
(3,'Pawan','M'),
(4,'Gopal','M'),
(5,'Sandeep','M'),
(6,'Isha','F'),
(7,'Sugandha','F'),
(8,'kritika','F')
 
--Verify Data
SELECT ID,NAME,GENDER FROM AlternateMaleFemale

/************   SOLUTION 1    | Pawan Kumar Khowal     ****************/
 
;WITH CTE AS
(
    SELECT *, ROW_NUMBER() OVER (PARTITION BY GENDER ORDER BY ID) rnk FROM AlternateMaleFemale
)
SELECT * FROM CTE ORDER BY rnk,ID

/*
 [ Normalize (Divide) Amount between Months ]  – In this puzzle we have Normalize (Divide) Amount between Months. Please check out the sample input and expected output for details.

Sample Input

Start	    End	        Amount
14-Apr-14	13-May-14	200
15-May-14	16-Jun-14	320
Expected Output

Start	    End	        Amount
14-Apr-14	30-Apr-14	100
01-May-14	13-May-14	100
15-May-14	31-May-14	160
01-Jun-14	16-Jun-14	160
*/


--Create Table
 
CREATE TABLE TestSplitData
(
 Start DATETIME
,EndDt DATETIME
,Amount INT
)
GO
 
--Insert Data
 
INSERT INTO TestSplitData(Start,EndDt,Amount)
VALUES
('14-Apr-14','13-May-14',200),
('15-May-14','16-Jun-14',320)
 
--Verify Data
 
SELECT Start,EndDt,Amount FROM TestSplitData

;with cte as
(
select Start,Dateadd(MM,datediff(MM,0,Start),30)[end],Amount/2 Amount,Row_number()over(partition by amount order by Start)rno from
(
SELECT Start,Amount FROM testSplitData
union all
select EndDt,Amount FROM TestSplitData
)t
)
select Case when rno=2 then dateadd(mm,datediff(MM,0,[end]),0) else Start End Start,
Case when rno=2 then Start else [end] end [end],Amount
from cte

/*
[ The Company Code Puzzle ]  – In this puzzle we have to change values of A, B and CompanyCode to NULL if repeating values are there. Please check out the sample input and expected output for details.

Sample Input

A	B	C	CompanyCode	GL
1	1	1	AA	1
1	1	2	AA	2
1	1	3	AA	3
1	1	4	AA	4
2	2	1	BB	1
2	2	2	BB	2
Expected Output

A	B	C	CompanyCode	GL
1	1	1	AA	1
NULL	NULL	2	NULL	2
NULL	NULL	3	NULL	3
NULL	NULL	4	NULL	4
2	2	1	BB	1
NULL	NULL	2	NULL	2
*/
--Create table
 
CREATE TABLE [dbo].[TheCompanyCode]
(
[A] [int] NULL,
[B] [int] NULL,
[C] [int] NULL,
[CompanyCode] [varchar](100) NULL,
[GL] [varchar](100) NULL
)
GO
 
--Insert Data
 
INSERT INTO TheCompanyCode(A,B,C,CompanyCode,GL)
VALUES
(1,    1,     1,     'AA',  001),
(1,    1,     2,     'AA',  002),
(1,    1,     3,     'AA',  003),
(1,    1,     4,     'AA',  004),
(2,    2,     1,     'BB',  001),
(2,    2,     2,     'BB',  002)
 
--Verify Data
 
SELECT * FROM TheCompanyCode

WITH CTE AS (
SELECT *
,ROW_NUMBER() over(partition by a,b,companycode order by a) AS Rn
FROM TheCompanyCode)
SELECT A,B,C,CompanyCode,GL FROM CTE
WHERE Rn=1
UNION ALL
SELECT NULL,NULL,C,NULL,GL FROM CTE
WHERE Rn>1

SELECT
CASE WHEN A = lag(A)OVER(PARTITION BY CompanyCode ORDER BY CompanyCode)Then NULL Else A End A,
CASE WHEN B = lag(B)OVER(PARTITION BY CompanyCode ORDER BY CompanyCode)Then NULL Else B End B,
C,
CASE WHEN CompanyCode = lag(CompanyCode)OVER(PARTITION BY CompanyCode ORDER BY CompanyCode)Then NULL Else CompanyCode End CompanyCode,
GL
FROM TheCompanyCode

/*Aviod duplicates*/
 
CREATE TABLE Test2DistinctCount
(
a Int
,b Int
)
Go
 
--Insert Data
 
INSERT INTO Test2DistinctCount VALUES
(1,1) , (1,2) , (1,3) , (1,1)
 
--Verify Data
 
SELECT a,b,ROW_NUMBER() OVER(PARTITION BY b order by (SELECT 1)) FROM Test2DistinctCount group by a,b

select a,b from Test2DistinctCount group by a,b

/*
[ Group By XML Path Puzzle ]  – In this puzzle we have to show distinct students and the courses & instructors comma separated. Please note that you have to use XML Path to solve this puzzle. Please check out the sample input and expected output for details.

Sample Input

StudentName	Course	Instructor	RoomNo
Mark	Algebra	Dr. James	101
Mark	Maths	Dr. Jones	201
Joe	Algebra	Dr. James	101
Joe	Science	Dr. Ross	301
Joe	Geography	Dr. Lisa	401
Jenny	Algebra	Dr. James	101
Expected Output

StudentName	Taught by
Jenny	Algebra by Dr. James in Room No 101
Joe	Algebra by Dr. James in Room No 101, Science by Dr. Ross in Room No 301, Geography by Dr. Lisa in Room No 401
Mark	Algebra by Dr. James in Room No 101, Maths by Dr. Jones in Room No 201
*/



 
CREATE TABLE TestTable 
(
  StudentName VARCHAR(100)
, Course VARCHAR(100)
, Instructor VARCHAR(100)
, RoomNo VARCHAR(100)
)
GO
 
-- Populate table
 
INSERT INTO TestTable (StudentName, Course, Instructor, RoomNo)
SELECT 'Mark', 'Algebra', 'Dr. James', '101'
UNION ALL
SELECT 'Mark', 'Maths', 'Dr. Jones', '201'
UNION ALL
SELECT 'Joe', 'Algebra', 'Dr. James', '101'
UNION ALL
SELECT 'Joe', 'Science', 'Dr. Ross', '301'
UNION ALL
SELECT 'Joe', 'Geography', 'Dr. Lisa', '401'
UNION ALL
SELECT 'Jenny', 'Algebra', 'Dr. James', '101'
GO
 
-- Check orginal data
 
SELECT StudentName, Course, Instructor, RoomNo
FROM TestTable
GO
SELECT b.StudentName 
            , STUFF 
                ((
                SELECT ', ' + Course + ' by ' + CAST(Instructor AS VARCHAR(MAX)) + ' in Room No ' + CAST(RoomNo AS VARCHAR(MAX))
                FROM TestTable a
                WHERE ( a.StudentName = b.StudentName )
                FOR XML PATH('')
                ) ,1,2,'') 
                AS cusr
FROM TestTable b
GROUP BY b.StudentName

/*
 [Covert Comma Separated Values to a Table using Cross Apply & XML Puzzle ]  – In this puzzle we have to get comma separated values into a table format using XML and Cross Apply operators. Please check out the sample input and expected output for details.

Sample Input

ID	VALUE
1	a,b,c
2	s,t,u,v,w,x
Expected Output

Id	SplitedValue
1	a
1	b
1	c
2	s
2	t
2	u
2	v
2	w
2	x
*/


 
CREATE TABLE TestCommaUsingCrossApply
(
ID INT
,VALUE VARCHAR(100)
)
GO
 
--Insert Data
 
INSERT INTO TestCommaUsingCrossApply(ID,VALUE)
VALUES
(1,'a,b,c'),
(2,'s,t,u,v,w,x')
 
--Verify Data
select ID,VALUE from TestCommaUsingCrossAppl
 
---------------------------------------
--Sol 1 | Pawan Kumar Khowal
---------------------------------------
 
 
SELECT Id,SplitedValue FROM
(
    SELECT ID,cast(('<X>'+replace(e.VALUE,',' ,'</X><X>')+'</X>') as xml) as xmlcol  FROM  TestCommaUsingCrossApply e 
) s
OUTER APPLY
(
    SELECT ProjectData.D.value('.', 'varchar(100)') as SplitedValue
    FROM s.xmlcol.nodes('X') as ProjectData(D)
) a 


/*
 [ The Candidate Joining Puzzle ] – In this puzzle we have to find out the valid candidate joining date for each candidate. E.g if you check for CID the joining date is 10-01-2015 and as per the company’s holiday table they have holiday. So in this case we have to prepone the joining by one day. Hence for CJ10101 the valid joining date would be 08-01-2015 as they have holiday on 09-01-2015 also. Please check out the sample input and expected output for details

Sample Input

CandidateJoining	
CId	CJoiningDate
CJ10101	10-01-2015
CJ10104	10-01-2015
CJ10105	18-02-2015
CJ10121	11-03-2015
CJ10198	11-04-2015
Holidays	
ID	HolidayDate
101	10-01-2015
102	09-01-2015
103	19-02-2015
104	11-03-2015
105	11-04-2015
Expected Output

CId	CJoiningDate	ValidJoiningDate
CJ10101	10-01-2015	08-01-2015
CJ10104	10-01-2015	08-01-2015
CJ10105	18-02-2015	18-02-2015
CJ10121	11-03-2015	10-03-2015
CJ10198	11-04-2015	10-04-2015

*/

CREATE TABLE Holidays
(
ID INT
,HolidayDate DATETIME
)
GO
 
--Insert Data
INSERT INTO Holidays(ID,HolidayDate)
VALUES
(101,'01/10/2015'),
(102,'01/09/2015'),
(103,'02/19/2015'),
(104,'03/11/2015'),
(105,'04/11/2015')
 
--Verify Data
SELECT ID,HolidayDate FROM Holidays
 
--Create Table
CREATE TABLE CandidateJoining
(
CId VARCHAR(17)
,CJoiningDate DATETIME
)
GO
 
--Insert Data
INSERT INTO CandidateJoining(CId,CJoiningDate)
VALUES
('CJ10101','01/10/2015'),
('CJ10104','01/10/2015'),
('CJ10105','02/18/2015'),
('CJ10121','03/11/2015'),
('CJ10198','04/11/2015')
 
--Verify Data
SELECT CId,CJoiningDate FROM CandidateJoining
 
;WITH CTE AS
(
    SELECT MIN(HolidayDate) MinDate , MAX(HolidayDate) MaxDate FROM
    (
        SELECT * , DAY(HolidayDate) - ROW_NUMBER() OVER (ORDER BY HolidayDate ASC) rnk FROM Holidays
    ) a GROUP BY rnk 
)
SELECT CId , CASE WHEN MinDate IS NULL THEN CJoiningDate ELSE MinDate -1 END CandidateJoining FROM CandidateJoining j
LEFT JOIN CTE c ON j.CJoiningDate BETWEEN c.MinDate AND c.MaxDate

;with cte
as
(
select cid,CJoiningDate,dateadd(day,-1,MIN(HolidayDate)) as validjoiningdate
from CandidateJoining a
left join Holidays b
on a.CJoiningDate=b.HolidayDate
or dateadd(day,-1,a.CJoiningDate)=b.HolidayDate
group by cid,CJoiningDate
)
select CId,CJoiningDate,case when validjoiningdate IS null then cjoiningdate
else validjoiningdate end as validjoiningdate
from cte

/*
 [ Consecutive Wins for India Puzzle ]  – In this puzzle we have to find the maximum consecutive wins for India in India Vs Australia series. Please check out the sample input and expected output for details.

Sample Input

TeamA	TeamB	MatchDate	WinsBy
Ind	Aus	10-01-2014	Ind
Ind	Aus	15-01-2014	Ind
Ind	Aus	19-01-2014	Ind
Ind	Aus	23-01-2014	Aus
Ind	Aus	27-01-2014	Ind
Ind	Aus	31-01-2014	Ind
Expected Output

TeamA	TeamB	MatchDate	WinsBy
Ind	Aus	10-01-2014	Ind
Ind	Aus	15-01-2014	Ind
Ind	Aus	19-01-2014	Ind
*/

 
CREATE TABLE IndAusSeries
(
TeamA VARCHAR(3)
,TeamB VARCHAR(3)
,MatchDate DATETIME
,WinsBy VARCHAR(3)
)
GO
 
--Insert Data
 
INSERT INTO IndAusSeries(TeamA,TeamB,MatchDate,WinsBy)
VALUES
('Ind','Aus','01-10-2014','Ind'),
('Ind','Aus','01-15-2014','Ind'),
('Ind','Aus','01-19-2014','Ind'),
('Ind','Aus','01-23-2014','Aus'),
('Ind','Aus','01-27-2014','Ind'),
('Ind','Aus','01-31-2014','Ind')
 
--Verify Data
 
SELECT TeamA,TeamB,MatchDate,WinsBy FROM IndAusSeries
GO
WITH CTE 
AS
(
    SELECT * 
        , RANK() OVER (PARTITION BY a.WinsBy,a.lag ORDER BY a.MatchDate) rnk
        , ROW_NUMBER() OVER (ORDER BY MatchDate) rnum 
    FROM
    (
        SELECT *, 
            REPLACE(lag(winsby,1,0) OVER (ORDER BY MatchDate),'0','Ind') lag 
        FROM IndAusSeries
    ) a
)
SELECT TeamA,TeamB,MatchDate,WinsBy from CTE where rnk = rnum

/*
[ The Football Puzzle ]  – In this puzzle we have to find 100th Champion which has most number of championships overall. Please check out the sample input and expected output for details.

Sample Input

club_id	club_name	championship_year	year_100th_champion
1	FENERBAHCE	2007	1
2	GALATASARAY	2006	0
3	BESIKTAS	2003	1
1	FENERBAHCE	2005	0
1	FENERBAHCE	2004	0
2	GALATASARAY	2002	0
2	GALATASARAY	2000	0
2	GALATASARAY	1999	0
2	GALATASARAY	1998	0
2	GALATASARAY	1997	0
1	FENERBAHCE	1996	0
1	FENERBAHCE	2001	0
1	FENERBAHCE	1989	0
1	FENERBAHCE	1985	0
Expected Output

club_name
FENERBAHCE
*/

 
Create table tr_football_league
(
club_id INT,
club_name Varchar(32),
championship_year INT,
year_100th_champion INT
)
 
--Insert Data
insert into tr_football_league values (1, 'FENERBAHCE', 2007, 1) ;
insert into tr_football_league values (2, 'GALATASARAY', 2006, 0) ;
insert into tr_football_league values (3, 'BESIKTAS', 2003, 1) ;
insert into tr_football_league values (1, 'FENERBAHCE', 2005, 0) ;
insert into tr_football_league values (1, 'FENERBAHCE', 2004, 0) ;
insert into tr_football_league values (2, 'GALATASARAY', 2002, 0) ;
insert into tr_football_league values (2, 'GALATASARAY', 2000, 0) ;
insert into tr_football_league values (2, 'GALATASARAY', 1999, 0) ;
insert into tr_football_league values (2, 'GALATASARAY', 1998, 0) ;
insert into tr_football_league values (2, 'GALATASARAY', 1997, 0) ;
insert into tr_football_league values (1, 'FENERBAHCE', 1996, 0);
insert into tr_football_league values (1, 'FENERBAHCE', 2001, 0) ;
insert into tr_football_league values (1, 'FENERBAHCE', 1989, 0) ;
insert into tr_football_league values (1, 'FENERBAHCE', 1985, 0) ;
 
--Verify Data
SELECT club_id, club_name , championship_year , year_100th_champion FROM tr_football_league

select top 1 club_name from tr_football_league group by club_name order by count(year_100th_champion) desc


/*
[SQL | Gold Rate Puzzle] – In the puzzle we have gold rate changing all the time. We have to find the start date, End Date and the gold rate at that duration. If the gold rate is changed then only we have create a new row. Please check the sample input and the expected output.

Sample Input

dt	Rate
18-09-2014	27000
19-09-2014	27000
20-09-2014	31000
21-09-2014	31000
22-09-2014	31000
23-09-2014	32000
24-09-2014	31000
25-09-2014	32000
26-09-2014	27000
Expected Output

StartDate	EndDate	Rate
18-09-2014	19-09-2014	27000
20-09-2014	22-09-2014	31000
23-09-2014	23-09-2014	32000
24-09-2014	24-09-2014	31000
25-09-2014	25-09-2014	32000
26-09-2014	26-09-2014	27000
*/

 
CREATE TABLE [dbo].[testGoldRateChange]
(
[dt] [datetime] NULL,
[Rate] [int] NULL
)
GO
 
--Insert Data
INSERT INTO [dbo].[testGoldRateChange](dt,Rate)
VALUES
('2014-09-18 06:25:19.897', 27000),
('2014-09-19 06:25:19.897', 27000),
('2014-09-20 06:25:19.897', 31000),
('2014-09-21 06:25:19.897', 31000),
('2014-09-22 06:25:19.897', 31000),
('2014-09-23 06:25:19.897', 32000),
('2014-09-24 06:25:19.897', 31000),
('2014-09-25 06:25:19.897', 32000),
('2014-09-26 06:25:19.897', 27000)
 
--Check data
SELECT dt,Rate FROM [dbo].[testGoldRateChange] order by dt

---------------------------------------
--Sol 1 | Pawan Kumar Khowal
---------------------------------------
 
; WITH CTE1 AS ( SELECT dt , Rate , ROW_NUMBER() OVER (ORDER BY dt) Rnk  FROM testGoldRateChange )
,CTE2 AS
(
SELECT *,  CASE WHEN
              Rate = ( SELECT Rate from CTE1 c3 WHERE c3.rnk =  ( SELECT MAX(c1.rnk) FROM CTE1 c1 WHERE c1.rnk < c2.rnk ))  
              THEN 0 ELSE 1 END Identifier,
            SUM(CASE WHEN
              Rate = ( SELECT Rate from CTE1 c3 WHERE c3.rnk =  ( SELECT MAX(c1.rnk) FROM CTE1 c1 WHERE c1.rnk < c2.rnk ))  
              THEN 0 ELSE 1 END) OVER (ORDER BY rnk ) cols                   
                       FROM CTE1 c2
)
SELECT MIN(dt) StartDate , MAX(dt) EndDate , MAX(Rate) Rate FROM CTE2 GROUP BY cols
 
 
---------------------------------------
--Sol 2 | Pawan Kumar Khowal
---------------------------------------
 
 
; WITH CTE1 AS
( 
       SELECT dt , Rate , ROW_NUMBER() OVER (ORDER BY dt) Rnk  FROM testGoldRateChange 
)
,CTE2 AS
(
       SELECT *,  CASE WHEN Rate = lag(Rate) over(order by rnk) THEN 0 ELSE 1 END cols FROM CTE1 c2
)
,CTE3 AS
(
       SELECT *,  SUM(cols) over(order by rnk) Grouper FROM CTE2 c2
)
SELECT MIN(dt) StartDate , MAX(dt) EndDate , MAX(Rate) Rate FROM CTE3 GROUP BY Grouper
 
 
;WITH cte AS
(
SELECT *, DATEPART(dd, dt) - ROW_NUMBER() OVER (PARTITION BY Rate ORDER BY dt) RN FROM [testGoldRateChange]
)
SELECT MIN(dt) StartDate, MAX(dt) EndDate, Rate FROM cte GROUP BY RN, Rate
ORDER BY StartDate

/*
Nth highest slary
*/

 
CREATE TABLE NthHighest
(
 Name  varchar(5)  NOT NULL,
 Salary  int  NOT NULL
)
 
--Insert the values
INSERT INTO  NthHighest(Name, Salary)
VALUES
('e5', 45000),
('e3', 30000),
('e2', 49000),
('e4', 36600),
('e1', 58000)
 
--Check data
SELECT Name,Salary FROM NthHighest

SELECT Name,SALARY FROM (
SELECT Name,Salary,ROW_NUMBER() OVER (ORDER BY Salary DESC) AS Rnk FROM NthHighest) R
WHERE R.Rnk =2

/*Department wise 2nd hishest salary

Department Table

DeptID	DeptName
1	Finance
2	IT
3	HR
Emps Table

EmpID	EmpName	DeptID	EmpSalary
101	Isha	1	7000
111	Esha	1	8970
102	Mayank	1	8900
103	Ramesh	2	4000
104	Avtaar	2	9000
105	Gopal	3	17000
106	Krishna	3	1000
107	Suchita	3	7000
108	Ranjan	3	17900
Expected Output

EmpID	EmpName	EmpSalary	DeptName
102	Mayank	8900	Finance
104	Avtaar	9000	IT
107	Suchita	7000	HR
*/
--Create Table
 
CREATE TABLE Department1
(
DeptID INT
,DeptName VARCHAR(10)
)
GO
 
--Insert Data
 
INSERT INTO Department1(DeptID,DeptName)
VALUES
(1,'Finance'),
(2,'IT'),
(3,'HR')
 
--Verify Data
 
SELECT DeptID,DeptName FROM Department1
 
--Create Table
 
CREATE TABLE Emps
(
EmpID INT
,EmpName VARCHAR(50)
,DeptID INT
,EmpSalary FLOAT
)
GO
 
--Insert Data
 
INSERT INTO Emps(EmpID,EmpName,DeptID,EmpSalary) VALUES
(101,'Isha',1,7000),
(111,'Esha',1,8970),
(102,'Mayank',1,8900),
(103,'Ramesh',2,4000),
(104,'Avtaar',2,9000),
(105,'Gopal',3,17000),
(106,'Krishna',3,1000),
(107,'Suchita',3,7000),
(108,'Ranjan',3,17900)
 
--Verify Data
 
SELECT EmpID,EmpName,DeptID,EmpSalary FROM Emps
go
with cte as
(
select EmpID,EmpName,EmpSalary,DeptName, DENSE_RANK() over (Partition by

DeptName order by EmpSalary Desc)as t from Emps,Department1 where

Emps.DeptID=Department1.DeptID

)select * from cte where t =2

/*
[ Developer Salary & the Manager Puzzle ] – Write a query which will find the developers with salary greater than their manager.

Sample Input

EmpID	EmpName	EmpSalary	MgrID
1	Pawan	80000	4
2	Dheeraj	70000	4
3	Isha	100000	4
4	Joteep	90000	NULL
5	Suchita	110000	4
Expected Output

EmpID	EmpName	EmpSalary	MgrID
3	Isha	100000	4
5	Suchita	110000	4


*/



CREATE TABLE [dbo].[EmpSalaryGreaterManager]
(
[EmpID] [int] NULL,
[EmpName] [varchar](50) NULL,
[EmpSalary] [bigint] NULL,
[MgrID] [int] NULL
)
GO
 
--Insert Data
INSERT INTO [EmpSalaryGreaterManager](EmpID,EmpName,EmpSalary,MgrID)
VALUES
(1,    'Pawan',      80000, 4),
(2,    'Dheeraj',    70000, 4),
(3,    'Isha',       100000,       4),
(4,    'Joteep',     90000, NULL),
(5,    'Suchita',    110000,       4)
 
--Verify Data
SELECT * FROM [dbo].[EmpSalaryGreaterManager]
 
 
SELECT e1.EmpID,e1.EmpName,e1.EmpSalary,e1.MgrID, e.EmpName Mgr FROM EmpSalaryGreaterManager e
INNER JOIN EmpSalaryGreaterManager e1 ON e.EmpID = e1.MgrID
WHERE e1.EmpSalary > e.EmpSalary

/*
[Movie Puzzle] – Write a query which will gets the movie details where Mr. Amitabh and Mr. Vinod acted together and their role is actor.

Sample Input

MName	AName	Roles
A	Amitabh	Actor
A	Vinod	Villain
B	Amitabh	Actor
B	Vinod	Actor
D	Amitabh	Actor
E	Vinod	Actor
Expected Output

MName	AName	Roles
B	Vinod	Actor
B	Amitabh	Actor
*/
CREATE TABLE [Movie]
(
 
[MName] [varchar] (10) NULL,
[AName] [varchar] (10) NULL,
[Roles] [varchar] (10) NULL
)
 
GO
 
--Insert data in the table
 
INSERT INTO Movie(MName,AName,Roles)
SELECT 'A','Amitabh','Actor'
UNION ALL
SELECT 'A','Vinod','Villan'
UNION ALL
SELECT 'B','Amitabh','Actor'
UNION ALL
SELECT 'B','Vinod','Actor'
UNION ALL
SELECT 'D','Amitabh','Actor'
UNION ALL
SELECT 'E','Vinod','Actor'
 
--Check your data
SELECT MName , AName , Roles FROM Movie
select * from Movie where MName in
(select MName from Movie where Roles = 'Actor' and (AName = 'Amitabh' or AName = 'Vinod')
group by MName having count(MName)>1)

/*
 [Finding Previous Value Puzzle] – Write a query which will extract the previous value from the currentQuota for each row.

Input

BusinessEntityID	SalesYear	CurrentQuota
275	2005	367000
275	2005	556000
275	2006	502000
275	2006	550000
275	2006	1429000
275	2006	1324000
Output ..> We need to extract the last value from the currentQuota ( Last Column )

BusinessEntityID	SalesYear	CurrentQuota	lagCurrentData
275	2005	367000	0
275	2005	556000	367000
275	2006	502000	556000
275	2006	550000	502000
275	2006	1429000	550000
275	2006	1324000	1429000


*/

 
CREATE TABLE [lag]
(
BusinessEntityID INT
,SalesYear   INT
,CurrentQuota  DECIMAL(20,4)
)
GO
 
INSERT INTO lag
SELECT 275 , 2005 , '367000.00'
UNION ALL
SELECT 275 , 2005 , '556000.00'
UNION ALL
SELECT 275 , 2006 , '502000.00'
UNION ALL
SELECT 275 , 2006 , '550000.00'
UNION ALL
SELECT 275 , 2006 , '1429000.00'
UNION ALL
SELECT 275 , 2006 ,  '1324000.00'


SELECT
BusinessEntityID
, SalesYear
, CurrentQuota
, LAG(CurrentQuota, 1, 0) OVER(ORDER BY CurrentQuota) AS lagCurrentData
FROM [lag]

SELECT *,ISNULL(LAG(CurrentQuota) OVER (ORDER BY CurrentQuota),0) as lagCurrentData
FROM [lag]