BACKUP DATABASE [SoftUni] 
	TO DISK = 'C:\Users\Alexander\Desktop\DB_RESTORE\softuni-backup.bak'

RESTORE DATABASE [SoftUni]
	FROM DISK = 'C:\Users\Alexander\Desktop\DB_RESTORE\softuni-backup.bak'