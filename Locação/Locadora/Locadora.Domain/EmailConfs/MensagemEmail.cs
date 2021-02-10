using Locadora.Domain.Entidades;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Locadora.Domain.EmailConfs
{
    public class MensagemEmail
    {
        public static string EmailConfirmacaoLocacao(Locacao locacao)
        {
            StringBuilder TabelaEquipamentos = new StringBuilder("");

            foreach (var itemEquipamento in locacao.Equipamentos)
            {
                var tabelaEquipamentos = $@"
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%' height='100px'>
                                                <tr>
                                                    <td width='150' valign='top'>
                                                    </td>
                                                    <td width='260' valign='top'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td style='padding: 25px 0 0 0;'>
                                                                    Nome: {itemEquipamento.Nome} <br /><br />
                                                                    Descricao: {itemEquipamento.Descricao} <br /><br />
                                                                    @QuantidadeAlugado <br /><br />
                                                                    ValorDiaria: <b>{itemEquipamento.ValorDiaria.ToString("R$ #,###.00")}</b> <br /><br />
                                                                    Cor: {itemEquipamento.Cor}  <br /><br />
                                                                    Modelo: {itemEquipamento.Modelo}  <br /><br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <hr />
                                                    </td>
                                                    <td width='150' valign='top'>
                                                    </td>
                                                </tr>
                                            </table>
                                            ";

                TabelaEquipamentos.Append(tabelaEquipamentos);
            }

            var stringHtml = $@"
                            <!DOCTYPE html>
                            <html lang='pt-br'>
                            <head>
                                <meta charset='UTF-8'>
                                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                <title>Locadora</title>
                            </head>
                            <body>
                                <table align='center' border='1' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse;'>
                                        <tr>
                                            <td align='center' bgcolor='#3f48cc' >
                                                Locadora de Ferramentas
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>
                                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                    <tr>
                                                        <td>
                                                            Olá {locacao.Cliente.Nome}, os equipamentos vão chegar em {locacao.DiasParaChegadaPedido().ToString()} de dias no endereço que consta no seu cadastro: <br /> <b>{locacao.Cliente.Endereco.ObterEnderecoCompleto()}</b>
                                                        <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                <tr>
                                                                    <td>
                                            
                                                                        Data da Locacao: {locacao.DataLocacao.ToString("dd/MM/yyyy")} <br />
                                                                        Data da Devolucao: {locacao.DataDevolucao.ToString("dd/MM/yyyy")} <br />
                                                                        Valor do Aluguel: {locacao.ValorAluguel.ToString("R$ #,###.00")} <br />
                                                                        Valor do Frete: {locacao.ValorFrete.ToString("R$ #,###.00")} <br />
                                                                        Valor total: {locacao.ValorTotal.ToString("R$ #,###.00")}
                                                                    <hr />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style='padding: 20px 0 30px 0;'>
                                                                        Segue abaixo a lista com os equipamentos alugados:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                            <tr>
                                                                                <td width='260' valign='top'>
                                                                                    <!-- Equipamentos -->
                                                                                    {TabelaEquipamentos.ToString()}

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        <!--  -->
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='padding: 30px 30px 30px 30px; background-color: #848beb;'>
                                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                    <tr>
                                                        <td width='75%'> &reg; Locadora de Ferramentas</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                </table>
                            </body>
                            </html>

                            ";

            return stringHtml;
        }
    }
}
