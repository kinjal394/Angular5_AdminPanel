# Angular5 AdminPanel

# SQL Database
 paste dbScript.sql file to your ssms and run it. It will create tables to your database.

# API Project
  -Change connectionstring according to your environment(appsetting.json,AdminAPI\DataServices\dalc.cs,AdminDemoContext.cs)
  -if your environment throw exception while saving any record then update your entity by using command which is already mention in \AdminAPI\AdminAPI\edmxUpdateCommand.txt
  -Build project and run
  
  
# Frontend Project
  - run command npm install
  - change url of api in environment folder.
  - run command ng serve --open
