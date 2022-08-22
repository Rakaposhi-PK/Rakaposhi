
#from mcr.microsoft.com/mssql/server:2019-latest
from mcr.microsoft.com/mssql/server:2017-latest

ENV SA_PASSWORD MyPass@1234
ENV ACCEPT_EULA Y

USER root

copy ./database /
copy ./database/scripts/CreateDB.sql /setup.sql

#copy ./database/storeprocds/*.sql /sps
#Run rm combine_sps.sql

copy ./database/storeprocds/*.sql /
RUN cat /*.sql > /combine_sps.sql

ENTRYPOINT ["/bin/bash","entrypoint.sh"]
CMD ["/opt/mssql/bin/sqlservr"]