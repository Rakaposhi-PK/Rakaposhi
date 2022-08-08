#!/bin/bash

<<<<<<< HEAD
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d master -i setup.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d RakaposhiDB -i combine_sps.sql
=======
sleep 90s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d master -i setup.sql
#/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d RakaposhiDB #-i combine_sps.sql
>>>>>>> 1005b15f35e86e18695eba79174950b9ee95d734
