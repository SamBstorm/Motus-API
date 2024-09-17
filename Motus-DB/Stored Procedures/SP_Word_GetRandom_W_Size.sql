
CREATE PROCEDURE SP_Word_GetRandom_W_Size
	@wordSize INT
AS
BEGIN
	SELECT TOP(1) UPPER([Word]) collate SQL_Latin1_General_CP1251_CS_AS 
		FROM [MiniLexique]
		WHERE LEN([Word]) = @wordSize
		ORDER BY NEWID()
END
