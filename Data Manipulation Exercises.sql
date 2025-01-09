
--  TO START
-- 1- Create a new database named "CompanyDB."
create database companyDB

-- 2- Create a schema named "Sales" within the "CompanyDB" database.
create schema Sales

-- 3- Create a table named "employees" with columns: employee_id (INT), first_name (VARCHAR), last_name (VARCHAR), and salary (DECIMAL) within the "Sales" schema.
--Note: on employee_id use sequence instead of identity.
create sequence i
	as int 
	start with 1
	increment by  1

create table Sales.employees (
    employee_id int primary key default(next value for i),
	first_name varchar(20),
	last_name varchar(20),
	salary decimal(10, 2)
)
-- 4- Alter the "employees" table to add a new column named "hire_date" with the data type DATE.
alter table Sales.employees
add hire_date date

-- 5- Add mock data to this table using https://www.mockaroo.com


-- DATA MANIPULATION Exercises:
-- 1- Select all columns from the "employees" table.
select *
from Sales.employees

-- 2- Retrieve only the "first_name" and "last_name" columns from the "employees" table.
select first_name, last_name
from Sales.employees

-- 3- Retrieve “full name” as one column from the "first_name" and "last_name" columns from the "employees" table.
select first_name + ' ' + last_name 'full name'
from Sales.employees

-- 4- Show the average salary of all employees. 
select avg(salary)
from Sales.employees

-- 5- Select employees whose salary is greater than 50000.
select first_name, last_name, salary
from Sales.employees
where salary > 50000

-- 6- Retrieve employees hired in the year 2020.
select *
from Sales.employees
where year(hire_date) > 2020

-- 7- List employees whose last names start with 'S.'
select first_name, last_name
from Sales.employees
where last_name like 'S%'

-- 8- Display the top 10 highest-paid employees.
select top(10) *
from Sales.employees
order by salary desc

-- 9- Find employees with salaries between 40000 and 60000.
select first_name, last_name, salary
from Sales.employees
where salary between 40000 and 60000

-- 10- Show employees with names containing the substring 'man.'
select first_name, last_name 
from Sales.employees
where first_name like '%man%' or last_name like '%man%'

-- 11- Display employees with a NULL value in the "hire_date" column.
select * 
from Sales.employees
where hire_date is null

-- 12- Select employees with a salary in the set (40000, 45000, 50000).
select first_name, salary
from Sales.employees
where salary in (40000, 45000, 50000)

-- 13- Retrieve employees hired between '2020-01-01' and '2021-01-01.'
select first_name, last_name, hire_date
from Sales.employees
where hire_date between '2020-01-01' and '2021-01-01'

-- 14- List employees with salaries in descending order.
select first_name, salary
from Sales.employees
order by salary desc

-- 15- Show the first 5 employees ordered by "last_name" in ascending order.
select top(5) first_name, last_name
from Sales.employees
order by last_name 

-- 16- Display employees with a salary greater than 55000 and hired in 2020.
select first_name, salary
from Sales.employees
where salary > 55000 and year(hire_date) = 2020

-- 17- Select employees whose first name is 'John' or 'Jane.'
select first_name
from Sales.employees
where first_name = 'John' or first_name = 'Jane'

-- 18- List employees with a salary less than or equal to 55000 and a hire date after '2022-01-01.'
select *
from Sales.employees
where salary <= 55000 and hire_date >'2022-01-01'

-- 19- Retrieve employees with a salary greater than the average salary.
select *
from Sales.employees
where salary > ( select avg(salary)
from Sales.employees
)

-- 20- Display the 3rd to 7th highest-paid employees.
select first_name, salary
from Sales.employees
order by salary desc
offset 2 row fetch next 5 rows only

-- 21- List employees hired after '2021-01-01' in alphabetical order.
select *
from Sales.employees
where hire_date > '2021-01-01'
order by first_name, last_name

-- 22- Retrieve employees with a salary greater than 50000 and last name not starting with 'A.'
select *
from Sales.employees
where salary > 50000 and last_name not like 'A%'

-- 23- Display employees with a salary that is not NULL.
select *
from Sales.employees
where salary is not null

-- 24- Show employees with names containing 'e' or 'i' and a salary greater than 45000.
select *
from Sales.employees
where (first_name like '%e%' or first_name like '%e%') and salary > 45000