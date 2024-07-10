
-- יצירת טבלת עובדים
create table Employees(code int primary key identity, 
id varchar(10) UNIQUE NOT NULL,
full_name varchar(20))

-- יצירת טבלת סיסמאות
create table Passwords(code int primary key identity, 
employee_code int foreign key references Employees(code),
password_string varchar(12),
password_expiry_date date,
has_access bit)

-- יצירת טבלת זמנים
create table Clock_Time(code int primary key identity, 
employee_code int foreign key references Employees(code),
entry_time datetime, 
exit_time datetime)

select * from Employees

declare @fullName VARCHAR(20)='Shmuel Yaffe', @id VARCHAR(10)='444999222', @code int;
declare @password VARCHAR(12)= '1234', @answer VARCHAR(250);

IF exists (select * from Employees where id= @id)
	begin
		--find the code from the exists employee
		select @code = (select code from Employees where id=@id)
	end
else
	begin
			-- הוספת עובד לטבלה
			INSERT into Employees values ( @id, @fullName);
			select @code=@@IDENTITY;
		end



IF exists (select * from Passwords WHERE employee_code=@code)
	begin
		if exists (select password_string From Passwords 
					WHERE employee_code=@code AND password_string=@password 
					AND has_access=1 )
				begin
					if exists (select password_string From Passwords 
					WHERE employee_code=@code AND password_string=@password 
					AND has_access=1 AND  password_expiry_date>=getdate())
						begin
							IF exists (SELECT * FROM Clock_Time 
							WHERE employee_code=@code AND exit_time is null)
								begin 								
									UPDATE Clock_Time set exit_time=GETDATE() 
									WHERE employee_code=@code AND exit_time is null; 
									select @answer='Exit time: ' + CONVERT (NVARCHAR, GETDATE(), 121);
								end
							else 
								begin
								INSERT INTO Clock_Time  VALUES (@code, GETDATE(), null); 
								select @answer='Entry time: ' + CONVERT (NVARCHAR, GETDATE(), 121);
								end
						end
					ELSE
						begin
						select @answer= 'you need to update your password';
						end
				end
		ELSE
			begin
			select @answer = 'wrong password';
			end
	end
ELSE
	begin
		INSERT INTO	Passwords VALUES (@code, @password, 
		DATEADD(day, 180, GETDATE()),
		1)
		select @answer= 'You created a worker and password';
	end

--	employee_code int foreign key references Employees(code),
--password_string varchar(12),
--password_expiry_date date,
--has_access

