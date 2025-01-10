ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime_Current_Time]
DEFAULT GETDATE() FOR [LastLoginTime]