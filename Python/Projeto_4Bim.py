import mysql.connector
from mysql.connector import Error
import pandas as pd

try:
    connection = mysql.connector.connect(host='localhost', database='univap', user='root', password='')

    if connection.is_connected():
        db_Info = connection.get_server_info()
        print("Conectado ao mysql versão", db_Info)
        cursor = connection.cursor()
        cursor.execute("select database();")
        record = cursor.fetchone()
    print("Você está conectado: ", record)

except Error as e:

    print("Erro na conexão", e)

finally:
    if connection.is_connected():
        cursor.close()
        connection.close()
        print("MySQL conexão fechada")


def dados():
    global conexao
    comandosql = conexao.cursor()
    comandosql.execute(f'Select * from disciplinasxprofessores')
    tabela = comandosql.fetchall()
    if comandosql.rowcount > 0:
        for registro in tabela:
            global dicionario = {'Código Disciplina no Curso' : {codigodsciplinanocurso}, 'Código Disciplica' : {coddisciplina}, 'Código Professor' : {codprofessor}, 'Curso' : {curso}, 'Carga Horária' : {cargahoraria}, 'Ano Letivo' : [anoletivo]}
            print(dicionario)


dados()
df = pd.DataFrame(dicionario)
print(df)
df.to_excel(r'c:/notas/ArthurGiuliaPedro.xlsx', sheet_name = 'Planilha1', na_rep = '#N/A', header = True, index = False)