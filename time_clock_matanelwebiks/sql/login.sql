DECLARE @time DATETIME = GETDATE();
DECLARE @code INT;
DECLARE @answer VARCHAR(100);

-- Retrieve employee code based on ID
SELECT @code = (SELECT code FROM Employees WHERE id = @id);

-- Check if user exists
IF @code IS NULL
    BEGIN
        SELECT @answer = 'User not found';
    END
-- Check if the password is correct and user has access
ELSE IF NOT EXISTS (SELECT code FROM Passwords WHERE employee_code = @code AND has_access = 1 AND password = @password)
    BEGIN
        SELECT @answer = 'User or password incorrect';
    END
-- Check if the password is expired
ELSE IF EXISTS (SELECT code FROM Passwords WHERE employee_code = @code AND has_access = 1 AND password = @password AND expiry_date <= GETDATE())
    BEGIN
        SELECT @answer = 'You need to change password';
    END
ELSE
    BEGIN
        -- Check if there is an existing entry without an exit time
        IF EXISTS (SELECT employee_code FROM Time WHERE employee_code = @code AND exit_time IS NULL)
            BEGIN
                -- Update exit time
                UPDATE Time 
                SET exit_time = @time 
                WHERE employee_code = @code AND exit_time IS NULL;
                SELECT @answer = 'Exit time is ' + CONVERT(NVARCHAR, @time, 121);
            END
        ELSE
            BEGIN
                -- Insert new entry time
                INSERT INTO Time (employee_code, entry_time, exit_time) 
                VALUES (@code, @time, NULL);
                SELECT @answer = 'Entry time is ' + CONVERT(NVARCHAR, @time, 121);
            END
    END

SELECT @answer;
