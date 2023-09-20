totallampadas = float()
while True:
    print("Quarto(1)\n"
          "Sala de TV(2)\n"
          "Salas(3)\n"
          "Cozinha(4)\n"
          "Varandas(5)\n"
          "Escritório(6)\n"
          "Banheiro(7)")
    resp = int(input('Digite um comodo entre os disponiveis: \n'))
    comprimento = int(input('Digite o comprimento do comodo: \n'))
    largura = int(input('Digite a largura do comodo: \n'))
    area = comprimento * largura

    if resp == 1 or resp == 2:
        print(f'O comodo escolhido foi: {resp}')
        print(f'Area do comodo e: {area}m²')
        potencia = area * 15
        print(f'A potencia e de: {potencia}w')
        lampada = potencia / 60
        print(f'A quantidade de lampadas necessarias nesse cômodo é: {lampada:.0f}')
        totallampadas = totallampadas + lampada
    elif resp == 3 or resp == 4 or resp == 5:
        print(f'O comodo escolhido foi: {resp}')
        print(f'Area do comodo e: {area}m²')
        potencia = area * 18
        print(f'A potencia e de: {potencia}w')
        lampada = potencia / 60
        print(f'A quantidade de lampadas necessarias nesse cômodo é: {lampada:.0f}')
        totallampadas = totallampadas + lampada
    elif resp == 6 or resp == 7:
        print(f'O comodo escolhido foi: {resp}')
        print(f'Area do comodo e: {area}m²')
        potencia = area * 20
        print(f'A potencia e de: {potencia}w')
        lampada = potencia / 60
        print(f'A quantidade de lampadas necessarias nesse cômodo é: {lampada:.0f}')
        totallampadas = totallampadas + lampada

    resp = input('Você deseja inserir outro cômodo? S/N ').upper()
    while resp != 'S' and resp != 'N':
        resp = input('Digite uma resposta válida!! ')

    if resp == 'N':
        break
print(f'O total de lampadas utilizadas na residência foi {totallampadas:.0f}')
print(f'A Potência total utilizada em sua residência é {totallampadas*60:.1f}W')