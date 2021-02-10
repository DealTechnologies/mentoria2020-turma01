export interface Carrinho
{
    idUsuario: string;
    equipamentos: [
    {
      id: string;
      nome: string;
      descricao: string;
      cor: string;
      modelo: string
      imagem: string
      saldoEstoque: number;
      valorDiaria: number;
      quantidadeAlugado: number;
    }
  ],
  dataLocacao: string;
  dataDevolucao: string;
  valorFrete: number;
  valorAluguel: number;
  valorTotal: number;
}