using Locadora.Domain.Entidades;
using System.Text;

namespace Locadora.Domain.EmailConfs
{
    public class MensagemEmail
    {
        public static string EmailConfirmacaoLocacao(Locacao locacao)
        {
            StringBuilder TabelaEquipamentos = new StringBuilder("");

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
                                                <img src='logo.png' alt='Locadora de Ferramentas' width='300' height='230' style='display: block;' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>
                                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                    <tr>
                                                        <td>
                                                            Olá {locacao.Cliente.Nome}, segue abaixo os equipamentos alugados por você!
                                                        <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                <tr>
                                                                    <td>
                                            
                                                                        Data da Locacao: {locacao.DataDevolucao.ToString("dd/MM/yyyy")} <br />
                                                                        Data da Devolucao: {locacao.DataDevolucao.ToString("dd/MM/yyyy")} <br />
                                                                        Valor do Aluguel: {locacao.ValorAluguel.ToString("R$ #,###.00")} <br />
                                                                        Valor do Frete: {locacao.ValorFrete.ToString("R$ #,###.00")} <br />
                                                                        Valor total: {locacao.ValorAluguel.ToString("R$ #,###.00")}
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
                                                                                    @tabelaEquipamentos

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
                                                        <td width='75%'>
                                                            &reg; Locadora de Ferramentas
                                                           </td>
                                                        <td align='right'>
                                                            <table border='0' cellpadding='0' cellspacing='0'>
                                                                <tr>
                                                                    <td>
                                                                        <a href='https://github.com/DealTechnologies/mentoria2020-turma01/tree/master/Loca%C3%A7%C3%A3o' target='_blank'>
                                                                            <img src='iconegithub.png' alt='Twitter' width='25' height='25' style='display: block;' border='0' />
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                </table>
                            </body>
                            </html>

                            ";

            foreach (var itemEquipamento in locacao.Equipamentos)
            {
                var tabelaEquipamentos = $@"
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%' height='100px'>
                                                <tr>
                                                    <td width='150' valign='top'>
                                                    </td>
                                                    <td width='260' valign='top'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-color: #cbd7de;'>
                                                            <tr>
                                                                <td>
                                                                    <img src='images/left.gif' alt='' width='100%' height='140' style='display: block;' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='padding: 25px 0 0 0;'>
                                                                    {itemEquipamento.Nome} <br /><br />
                                                                    {itemEquipamento.Descricao} <br /><br />
                                                                    @Quantidade <br /><br />
                                                                    {itemEquipamento.ValorDiaria} <br /><br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width='150' valign='top'>
                                                    </td>
                                                </tr>
                                            </table>
                                            ";

                TabelaEquipamentos.Append(tabelaEquipamentos);
            }

            stringHtml.Replace("@tabelaEquipamentos", TabelaEquipamentos.ToString());

            return stringHtml;
        }
    }
}
