
-- 1-Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
CREATE TABLE employees (
    id INT,
    name VARCHAR(30),
    salary DECIMAL(7, 2)
)

-- 2-Add a new column named "Department" to the "Employees" table with data type varchar(50).
ALTER TABLE employees
ADD department VARCHAR(50)


-- 3-Remove the "Salary" column from the "Employees" table.
ALTER TABLE employees
DROP COLUMN salary

-- 4-Rename the "Department" column in the "Employees" table to "DeptName".
EXEC sp_rename 'employees.department', 'DeptName', 'COLUMN'

-- 5-Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
CREATE TABLE projects (
    project_id INT,
    project_name varchar(50)
)

-- 6- Add a primary key constraint to the "Employees" table for the "ID" column.
ALTER TABLE employees
ADD PRIMARY KEY(id)


-- 7- Add a unique constraint to the "Name" column in the "Employees" table.
ALTER TABLE employees
ADD UNIQUE(name)

-- 8- Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar), and Email (varchar), and Status (varchar).
CREATE TABLE customers (
    customers_id INT,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(50),
    status VARCHAR(20)
)

-- 9- Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
ALTER TABLE customers
ADD UNIQUE (first_name, last_name)


-- 10- Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime), and TotalAmount (decimal).
CREATE TABLE orders (
    order_id INT,
    customer_id INT,
    order_date DATETIME,
    total_amount DECIMAL(8, 2)
)

-- 11- Add a check constraint to the "TotalAmount" column in the "Orders" table to ensure that it is greater than zero.
ALTER TABLE orders
ADD CHECK (total_amount > 0)

-- 12- Create a schema named "Sales" and move the "Orders" table into this schema.
CREATE SCHEMA sales
ALTER SCHEMA sales TRANSFER orders


-- 13- Rename the "Orders" table to "SalesOrders."
EXEC sp_rename  'sales.orders', 'SalesOrders'

