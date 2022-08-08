del combine_sps.sql
for /R %%f in (..\storeprocds\*.sql) do type "%%f" >> combine_sps.sql