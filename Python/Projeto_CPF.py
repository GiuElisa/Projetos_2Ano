cpf=[]
verif1=[]
aux1=[]
verif2 = []
aux2 = []
dados = {}
listadados = []
qtdteste=qtdvalido=qtdinvalido=0

while True:
   soma=0
   qtdteste += 1

   strcpf = input("Digite seu CPF: ")
   while len(strcpf) != 11 or strcpf.isnumeric() == False:
      strcpf = input("Digite corretamente os 11 dígitos do CPF: \n")

   for x in range(0,11):
      cpf.append(int(strcpf[x]))

   dados['CPF'] = cpf[:]
   d10 = cpf[9]
   d11 = cpf[10]

   y=10
   for x in range(0,9):
      verif1.append(cpf[x])
      aux1.append(y)
      aux1[x] *= verif1[x]
      soma += aux1[x]
      y-=1

   resto = soma % 11

   if resto < 2:
      cpf[9] = 0
   else:
      cpf[9] = 11 - resto

   soma=0
   y=11
   for x in range(0,10):
      verif2.append(cpf[x])
      aux2.append(y)
      aux2[x] *= verif2[x]
      soma += aux2[x]
      y-=1

   resto = soma % 11
   if resto < 2:
      cpf[10] = 0
   else:
      cpf[10] = 11 - resto

   if d10 == cpf[9] and d11 == cpf[10]:
      dados['Validacao'] = 'Válido'
      qtdvalido += 1
   else:
      dados['Validacao'] = 'Inválido'
      qtdinvalido +=1

   listadados.append(dados.copy())
   aux1.clear()
   verif1.clear()
   aux2.clear()
   verif2.clear()
   cpf.clear()

   print('-='*30)
   resp = str(input('Deseja continuar realizando testes de validação de cpf?[s/n]:')).lower()
   while resp != 's' and resp != 'n':
      resp = str(input('Deseja continuar realizando testes de validação de cpf?[s/n]:')).lower()
   if resp == 'n':
      break

por100valido = qtdvalido/qtdteste * 100
por100invalido = 100 - por100valido
print(f'Quantidade de testes: {qtdteste}')
print(f'Quantidade de CPF´s válidos: {qtdvalido}')
print(f'Quantidade de CPF´s inválidos: {qtdinvalido}')
print(f'Porcentagem de CPF´s válidos em relação ao total {por100valido:.2f}%')
print(f'Porcentagem de CPF´s inválidos em relação ao total {por100invalido:.2f}%')
print(listadados)
