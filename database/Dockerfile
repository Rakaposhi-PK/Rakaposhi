from mcr.microsoft.com/mssql/server:2019-latest
ENV SA_PASSWORD MyPass@1234
ENV ACCEPT_EULA Y

copy ./database /
copy scripts/CreateDB.sql /setup.sql
copy ./database/storeprocds/*.sql /

ENTRYPOINT ["/bin/bash","entrypoint.sh"]
CMD ["/opt/mssql/bin/sqlservr"]
