FROM postgres:latest

# Copie os arquivos SQL para inicializar o banco de dados
COPY ./data/*.sql /docker-entrypoint-initdb.d/

# Exponha a porta padrão do PostgreSQL
EXPOSE 5432
