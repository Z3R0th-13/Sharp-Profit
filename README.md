# Sharp-Profit

<img src="https://github.com/Z3R0th-13/Sharp-Profit/blob/master/images/Banner.PNG">

#Profit is a C# version of my Profit script. This version can be utilized with Cobalt Strike's execute-assembly function. Seeing as how most people are moving away from PowerShell I figured this would be a good learning opportunity. This is my first program made in C#, so I’m sure the flow isn’t the greatest. Let me know any improvements that could be made or additional functionality!

Common files and extensions this program looks for are as follows:
* Password: (If a user saves a file with password in the name)
* NTUSER.DAT: (Contains registry entries for each user on a system)
* SAM: (Can be volume shadow copied)
* Hosts: (Maps hostnames to IP addresses)
* Unattend: (Can contain password information
* KeePass: (Can possibly attack these files to gain passwords)
* .sav: (Save files)
* .sql: (SQL files)
* .tar: (Files compressed with TAR)
* .bak: (Backup files)
* .pst: (Outlook personal files)
* .settingcontent-ms: (Windows control panel files)
* .py (Python Scripts)
* .yaml (YAML Ain't Markup Language Files)

Sharp-Profit also searches the interesting files found for passwords/credentials. 
