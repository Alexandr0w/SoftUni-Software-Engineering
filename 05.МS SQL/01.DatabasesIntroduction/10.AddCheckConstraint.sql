ALTER TABLE [Users]
ADD CONSTRAINT [CK_Password_Min_Length_5]
CHECK(LEN([Password]) >= 5)