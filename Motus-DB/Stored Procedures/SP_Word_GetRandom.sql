﻿
CREATE PROCEDURE SP_Word_GetRandom
AS
BEGIN
	SELECT TOP(1) UPPER([Word]) collate SQL_Latin1_General_CP1251_CS_AS 
		FROM [MiniLexique]
		ORDER BY NEWID()
END
