#!/bin/bash
set -e

echo "$1"

if [ ! -f tmp/app-initialized ]; then
  function initialize_app_database(){
     sleep 90s

     #/run-script.sh & /opt/mssql/bin/sqlservr
     /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d master -i setup.sql
     touch tmp/app-initialized
  } 
  initialize_app_database &
fi

sleep 60s
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MyPass@1234 -d master -i setup.sql
#/run-script.sh & /opt/mssql/bin/sqlservr 

exec "$@"
