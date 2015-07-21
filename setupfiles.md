# Setting up the XML Configuration Files #

There are two important XML configuration files that reside in the same directory as the application.

# connection.xml #

This file contains database connection information - should be relatively straightforward.

```
<Configuration>
  <!-- database name that will be selected -->
  <Database>dbname</Database>
  <!-- the user which will connect to the database -->
  <User>user</User>
  <!-- the password which will be used to connect to the dataabse -->
  <Password>password</Password>
  <!-- the host name / ipaddress of the database -->
  <Host>localhost</Host>
  <!-- the database port to used -->
  <Port>3306</Port>
  <!-- if the php PEQ editor is setup input the address here for quick linking within the application -->
  <PEQEditorUrl>http://localhost/</PEQEditorUrl>
</Configuration>
```

# config.xml #

This file provides configuration for the SQL queries that will be used... details to come..