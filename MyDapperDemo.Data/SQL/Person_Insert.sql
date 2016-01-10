INSERT INTO tblPerson
	 (LastName, FirstName, DirectEmail, MobilePhone) 
VALUES 
	(@LastName, @FirstName, @DirectEmail, @MobilePhone);
 SELECT CAST(SCOPE_IDENTITY() as int);