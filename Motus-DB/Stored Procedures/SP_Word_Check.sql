
CREATE PROCEDURE SP_Word_Check
	@word VARCHAR(80)
AS
BEGIN
	SELECT DISTINCT [Word]
		FROM [MiniLexique]
		WHERE (UPPER([Word]) collate SQL_Latin1_General_CP1251_CS_AS) LIKE UPPER(@word) collate SQL_Latin1_General_CP1251_CS_AS
END
