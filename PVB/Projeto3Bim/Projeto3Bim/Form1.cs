/* *******************************************************************
* Colégio Técnico Antônio Teixeira Fernandes (Univap)
* Curso Técnico em Informática - Data de Entrega: 05/09/2022
* Autores do Projeto: Giulia Elisa Pereira
*                     Natalia Costa dos Santos
* Turma: 2H
* Projeto 3º Bimestre
* Observação: button1 _ Aciona a cadeia de eventos (calcular as parcelas, armazena dados os dados necessários do sistema, etc)
*             button2 _ Realiza o pagamento das parcelas
*             textbox1 _ Recebe o valor da compra
*             textbox2 _ Recebe a quantidade de parcelas
*             listbox1 _ Mostra as parcelas e a data de vencimento
*             label1 _ Mostra o total a pagar
*             label2, label3 _ Texto de identificação das caixas de texto
*             label4 _ Mostra os avisos, de pagamento efetuado, pagamento atrasado com juros, ou parcela pendente
*             dateTimePicker1 _ Calendário para escolher as datas, utiliza a data do sistema para realizar a compra
* 
* Projeto3Bim.cs
* ************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3Bim
{
    public partial class Form1 : Form
    {
        float valor, num, diferenca, valorParcela, resto, aux;
        int qtdParcelas;
        DateTime addMeses = new DateTime();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PARTE 1

            //Limpa a listbox
            listBox1.Items.Clear();

            //Variável que armazena o valor da compra
            valor = float.Parse(textBox1.Text);

            //Variável que armazena a quantidade de parcelas
            qtdParcelas = int.Parse(textBox2.Text);

            //Teste condicional para testar valores válidos
            if ((valor <= 0) || (qtdParcelas <= 1))
            {
                label1.Text = "Valores inválido! Digite novamente.";
            }
            else
            {
                //Variável que vai calcular o valor da parcela
                num = valor / qtdParcelas;

                //Função para armazenar a data do sistema
                DateTime data = dateTimePicker1.Value;

                //Função para descobrir o dia da semana
                DayOfWeek semana = new DayOfWeek();
                semana = data.DayOfWeek;

                //Teste condicional para o dia útil, retorna int, 0 é domingo e 6 é sábado
                int dia = (int)data.DayOfWeek;
                if (dia == 0)
                {
                    data = data.AddDays(1);
                }
                else if (dia == 6)
                {
                    data = data.AddDays(2);
                }

                // Seleciona o modo de seleção para múltiplo
                listBox1.SelectionMode = SelectionMode.MultiExtended;

                //Começa a atualizar e adicionar os itens na lista
                listBox1.BeginUpdate();

                //Para printar as parcelas e suas data de vencimento falta calcular e a formatação de saída
                for (int cont = 0; cont < qtdParcelas; cont++)
                {
                    //Calcula a diferença se houver
                    diferenca = valor - num * qtdParcelas;
                    valorParcela = !(cont + 1 == qtdParcelas) ? num : (num + diferenca);

                    //Calcula a data de vencimeto
                    addMeses = data.AddMonths(cont);

                    string v = String.Format("| Valor da parcela: R${0:0.00} ", valorParcela);

                    //Mostra a quantidade de parcela, o valor e a data de vencimento
                    listBox1.Items.Add((cont+1) + "º parcela " + v.ToString() + " | Data de Vencimento: " + addMeses.ToString("dd/MM/yyyy"));
                }

                //Para de atualizar a lista
                listBox1.EndUpdate();

                //Mostra o total a pagar
                label1.Text = String.Format("Total a Pagar = {0:C2}", valor);

            }
        }
            
        //PARTE 2

        //PAGAMENTO
        private void button2_Click(object sender, EventArgs e)
        {
            //Só executa se a parcela selecionada for a primeira da lista
            if (listBox1.GetSelected(0))
            {
                //Variável que recebe a data atual
                DateTime dataPagamento = dateTimePicker1.Value;

                //Adiciona os meses
                addMeses = addMeses.AddMonths(1);

                //Verificação do dia útil
                int diaDaSemana = (int)addMeses.DayOfWeek;

                //Recebe a data atual para verificação
                DateTime foiPago = dataPagamento;
                if (diaDaSemana == 0)
                {
                    foiPago = foiPago.AddDays(1);
                }
                else if (diaDaSemana == 6)
                {
                    foiPago = foiPago.AddDays(2);
                }

                //Comparar se o pagamento foi antes ou depois da data, calcula os juros
                if (DateTime.Compare(dataPagamento, foiPago) > 0)
                {
                    float comJuros = valorParcela + (valorParcela * 3 / 100);
                    label4.Text = String.Format("Pacela atrasada! Pagamento com juros de 3%. \nValor: {0:C2}", comJuros);

                }
                else
                {
                    label4.Text = String.Format("Pagamento Efetuado! \nValor: {0:C2}", valorParcela);

                }

                //Remove a parcela paga
                listBox1.Items.RemoveAt(0);

                //Termina a atualização da lista
                listBox1.EndUpdate();

                //Subtrai o valor da label
                aux = aux + valorParcela;
                resto = valor - aux;
                label1.Text = String.Format("Valor: {0:C2}", resto);

            }
            else
            {
                //Mensagem mostrada quando há parcela pendente, não deixa pagar
                label4.Text = String.Format("Impossível realizar o pagamento,\nhá parcelas pendentes!");
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
