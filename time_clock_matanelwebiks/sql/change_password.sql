DECLARE @code INT;
DECLARE @answer VARCHAR(100);

-- Retrieve employee code based on ID
SELECT @code = (SELECT code FROM Employees WHERE id = @id);

-- Check if user exists
IF @code IS NOT NULL
BEGIN
    -- Check if the old password is correct and user has access
    IF EXISTS (SELECT * FROM Passwords WHERE employee_code = @code AND password = @old_password AND has_access = 1)
    BEGIN
        -- Check if the new password is already used
        IF NOT EXISTS (SELECT * FROM Passwords WHERE employee_code = @code AND password = @new_password)
        BEGIN
            -- Update the old password to inactive and insert the new password
            UPDATE Passwords SET has_access = 0 WHERE employee_code = @code AND password = @old_password;
            INSERT INTO Passwords (employee_code, password, expiry_date, has_access) VALUES (@code, @new_password, DATEADD(day, 180, GETDATE()), 1);
            SELECT @answer = 'The expiry date is 180 days';
        END
        ELSE
        BEGIN
            SELECT @answer = 'You already used this password';
        END
    END
    ELSE
    BEGIN
        SELECT @answer = 'Password incorrect';
    END
END
ELSE
BEGIN
    SELECT @answer = 'Username or password incorrect';
END

SELECT @answer;
