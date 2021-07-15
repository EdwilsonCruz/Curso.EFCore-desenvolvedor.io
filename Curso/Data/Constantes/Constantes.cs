using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoEFCore.Data.Constantes
{
    public struct Constantes
    {
        public struct Tabelas
        {
            public const string Cliente = "Cliente";
            public const string Pedido = "Pedido";
            public const string Produto = "Produto";
            public const string PedidoItem = "PedidoItem";
            public const string CursoEFCore = "CursoEFCore";

        }

        public struct Schemas
        {
            public const string Sistema = "Sistema";
            public const string Identidade = "Identidade";
            public const string Migracao = "Migracao";
        }
    }
}
