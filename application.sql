INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Vignesh','9944711655','jeevabt@gmail.com','Mancity!11','User');
INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Ashok','9944367638','ashok.jeev@gmail.com','Arsenal!11','ADMIN');
INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Karthi','9003796721','karthikeyan.ravi11@gmail.com','Karthi!11','user');
INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Bemina','8220385215','beminaravi@gmail.com','Bemina@27','user');
INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Karthi','9003796721','karthiravi@gmail.com','Karthi!11','user');
SELECT * FROM RegistrationTable;

DROP table RegistrationTable;
CREATE TABLE RegistrationTable
(
CustomerId int IDENTITY(1,1) PRIMARY KEY,
FullName varchar(20) NOT NULL,
PhoneNumber varchar(10)UNIQUE NOT NULL,
Mail varchar(20)UNIQUE NOT NULL,
Password varchar(20)NOT NULL,
Role varchar(10),
CreatetAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP 
)
GO

CREATE PROCEDURE Registration
@FullName varchar(20),
@PhoneNumber varchar(20),
@Mail varchar(20),
@Password varchar(20),
@Role varchar(10)
AS
BEGIN
	INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES(@FullName,@PhoneNumber,@Mail,@Password,@Role);
END
DROP PROCEDURE LogIn;
CREATE PROCEDURE LogIn
@MailId varchar(20),
@Password varchar(20),
@Error varchar(20) OUT
AS
BEGIN
	SELECT * from RegistrationTable WHERE Mail=@MailId AND Password=@Password;
	BEGIN
		IF EXISTS (SELECT * from RegistrationTable WHERE Mail=@MailId AND Password=@Password)
			SET @Error='LogIn successfull';
		ELSE
			SET @Error='LogIn Failed';
	END
END 
SELECT * FROM RegistrationTable;
CREATE PROCEDURE UpdateDetails
@MailId varchar(20),
@PhoneNumber varchar(10)
AS
BEGIN
	UPDATE RegistrationTable SET PhoneNumber=@PhoneNumber WHERE Mail=@MailId;
END

BEGIN TRANSACTION

INSERT INTO RegistrationTable(FullName,PhoneNumber,Mail,Password,Role)VALUES('Sarath','9003796671','saratheee@gmail.com','Sarath@21','user');

UPDATE RegistrationTable SET Mail='karthikeyan@gmail.com' WHERE FullName='Karthi';

DELETE FROM RegistrationTable WHERE FullName='Ashok';

ROLLBACK TRANSACTION

COMMIT TRANSACTION

 select * from RegistrationTable;
