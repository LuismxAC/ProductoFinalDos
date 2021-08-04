using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using ClassCapaEntidades;
using MiAccesoSQL;

namespace ClassCapaLogicaNegocios
{
    public class ClassLogicaCarniceria
    {
        private ClassAccesoSQL Objacceso = new ClassAccesoSQL
        (
            @"Data Source=LEOPARDO\SQLEXPRESS; Initial Catalog=PedidosCarniceria; Integrated Security=true;"
        );
        public Boolean InsertaCliente(Cliente nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.Nombre
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "app",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.ApellP
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "apm",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.ApellM
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "cel",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 20,
                Value = nuevo.Celular
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = nuevo.Email
            };
            string sqlInsert = "INSERT INTO Cliente (Nombre, App, ApM, Celular, Correo) VALUES (@nom, @app, @apm, @cel, @email);";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, params1);
            return salida;
        }
        public List<Cliente> MuestraClientes(ref string m, ref string i, ref string t)
        {
            SqlConnection cnxTemp = null;
            string q1 = "SELECT * FROM Cliente";

            cnxTemp = Objacceso.AbrirConexion(ref m, ref i, ref t);
            SqlDataReader atrapa = null;
            atrapa = Objacceso.ConsultaDataReader(q1, cnxTemp, ref m, ref i, ref t);

            List<Cliente> salida = new List<Cliente>();

            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    salida.Add(new Cliente
                    {
                        id = (int)atrapa[0],
                        Nombre = (string)atrapa[1],
                        ApellP = (string)atrapa[2],
                        ApellM = (string)atrapa[3],
                        Celular = (string)atrapa[4],
                        Email = (string)atrapa[5]
                    });
                }
            }
            else
            {
                salida = null;
            }
            cnxTemp.Close();
            cnxTemp.Dispose();
            return salida;
        }
        public DataTable CLientesGrid(ref string m, ref string i, ref string t)
        {
            string query2 = "SELECT * FROM Cliente";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDaSet(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }
        public Boolean InsertaCarnicero(Carnicero nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 190,
                Value = nuevo.Nombre
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "cel",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 20,
                Value = nuevo.Telefono
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = nuevo.Correo
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "exp",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = nuevo.Experiencia
            };
            string sqlInsert = "INSERT INTO Carnicero (Nombre, Celular, Correo, Exp_anios) VALUES (@nom, @cel, @email, @exp);";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, params1);
            return salida;
        }
        public DataTable CarnicerosGrid(ref string m, ref string i, ref string t)
        {
            string query2 = "SELECT * FROM Carnicero";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDaSet(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }
        public string[] CompruebaExistenciaCli(Cliente cli, ref string m, ref string i, ref string t)
        {
            SqlConnection cnxTemp = null;
            SqlParameter[] pSQL = new SqlParameter[1];
            pSQL[0] = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = cli.Email
            };
            string q1 = "SELECT COUNT(*), Nombre, App, ApM, correo, celular, id_Cliente FROM Cliente WHERE Correo = @email GROUP BY Nombre, App, ApM, correo,celular, id_Cliente; ";
            string[] status = null;

            cnxTemp = Objacceso.AbrirConexion(ref m, ref i, ref t);
            SqlDataReader atrapa = null;
            atrapa = Objacceso.ConsultaDRP(q1, cnxTemp, ref m, ref i, ref t, pSQL);

            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    if ((int)atrapa[0] > 0)
                    {
                        status = new string[7];
                        status[0] = atrapa[0].ToString();
                        status[1] = atrapa[1].ToString();
                        status[2] = atrapa[2].ToString();
                        status[3] = atrapa[3].ToString();
                        status[4] = atrapa[4].ToString();
                        status[5] = atrapa[5].ToString();
                        status[6] = atrapa[6].ToString();
                        m = "Un momento";
                        t = "Ya estas registrado";
                        i = "success";
                    }
                    else
                    {
                        status = null;
                    }
                }
            }
            cnxTemp.Close();
            cnxTemp.Dispose();
            return status;
        }

        public Boolean AbrirPedido(Pedido nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "fcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.FCliente
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "fcar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.FCarnicero
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = nuevo.Envio
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "pag",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = nuevo.Pago
            };

            string sqlInsert = "INSERT INTO Pedido (FechaHora, F_Cliente, F_Carnicero, Envio, Pago) VALUES (GETDATE(), @fcli, @fcar, @env, @pag)";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, params1);
            return salida;
        }
        public DataTable PedidosGrid(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT id_Pedido AS Pedido, FechaHora, CONCAT(Cliente.Nombre, ' ', App, ' ', ApM) AS Cliente, Carnicero.Nombre AS Carnicero, Envio, Pago FROM Pedido INNER JOIN Cliente ON Pedido.F_Cliente = Cliente.id_Cliente INNER JOIN Carnicero ON Pedido.F_Carnicero = Carnicero.id_Carnicero WHERE F_Cliente = @idcli";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }
        public List<Carnicero> MuestraCarniceros(ref string m, ref string i, ref string t)
        {
            SqlConnection cnxTemp = null;
            string q1 = "SELECT * FROM Carnicero;";

            cnxTemp = Objacceso.AbrirConexion(ref m, ref i, ref t);
            SqlDataReader atrapa = null;
            atrapa = Objacceso.ConsultaDataReader(q1, cnxTemp, ref m, ref i, ref t);

            List<Carnicero> salida = new List<Carnicero>();

            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    salida.Add(new Carnicero
                    {
                        id = (int)atrapa[0],
                        Nombre = (string)atrapa[1],
                        Telefono = (string)atrapa[2],
                        Correo = (string)atrapa[3],
                        Experiencia = (Int16)atrapa[4],
                    });
                }
            }
            else
            {
                salida = null;
            }
            cnxTemp.Close();
            cnxTemp.Dispose();
            return salida;
        }

        public Boolean InsertarProducto(Productos nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 190,
                Value = nuevo.Nombre
            };
            p[1] = new SqlParameter
            {
                ParameterName = "pes",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.Peso
            };
            p[2] = new SqlParameter
            {
                ParameterName = "cant",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = nuevo.Cantidad
            };
            p[3] = new SqlParameter
            {
                ParameterName = "not",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = nuevo.Nota
            };
            p[4] = new SqlParameter
            {
                ParameterName = "idPed",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.FPedido
            };
            string sqlInsert = "INSERT INTO Producto (NombreProd, Cantidad, Peso, NotaEspecial, F_Pedido) VALUES (@nom, @cant,@pes, @not, @idPed);";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, p);
            return salida;
        }

        public DataTable ProductosGrid(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idPed",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT * FROM Producto WHERE F_Pedido = @idPed";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }






        public Boolean InsertarUbicacion(Ubicacion nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter
            {
                ParameterName = "col",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 120,
                Value = nuevo.Colonia
            };
            p[1] = new SqlParameter
            {
                ParameterName = "caynu",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 120,
                Value = nuevo.Calleynumero
            };
            p[2] = new SqlParameter
            {
                ParameterName = "muni",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.Municipio
            };
            p[3] = new SqlParameter
            {
                ParameterName = "cid",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.Ciudad
            };
            p[4] = new SqlParameter
            {
                ParameterName = "ref",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 120,
                Value = nuevo.Referencia
            };
            p[5] = new SqlParameter
            {
                ParameterName = "car",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 100,
                Value = nuevo.Caracteristica
            };
            p[6] = new SqlParameter
            {
                ParameterName = "cp",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 10,
                Value = nuevo.CP
            };
            p[7] = new SqlParameter
            {
                ParameterName = "idCli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.F_Cliente
            };
            string sqlInsert = "INSERT INTO Ubicacion (Colonia, Calleynumero, Municipio, Ciudad, Referencia, Caracteristica, CP, F_Cliente) VALUES (@col, @caynu, @muni, @cid,@ref,@car,@cp,@idCli); ";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, p);
            return salida;
        }
        public DataTable VerUbicaciones(ref string m, ref string i, ref string t)
        {
            string query2 = "SELECT id_ubicacion AS Num, Colonia, Calleynumero AS Calle, Municipio, Ciudad, Referencia, Caracteristica, CP FROM Ubicacion;";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDaSet(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }

        public Boolean FinalizarPedido(EntregaPedido nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter
            {
                ParameterName = "fp",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.F_Pedido
            };
            string sqlInsert = "INSERT INTO EntregaPedido (F_Pedido, Salida, Estado) VALUES (@fp, GETDATE(), 'Pendiente');";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, p);
            return salida;
        }
        public DataTable VerEntrega(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idPed",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT id_Entrega AS Entrega, Nombre AS Repartidor, Salida, SeEntrego, Estado FROM EntregaPedido INNER JOIN Repartidor ON EntregaPedido.F_Repartidor = Repartidor.id_Repartidor WHERE F_Pedido = @idPed";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }





        public string[] CompruebaExistenciaCarn(Carnicero car, ref string m, ref string i, ref string t)
        {
            SqlConnection cnxTemp = null;
            SqlParameter[] pSQL = new SqlParameter[1];
            pSQL[0] = new SqlParameter
            {
                ParameterName = "email",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = car.Correo
            };
            string q1 = "SELECT COUNT(*), Nombre, id_Carnicero FROM Carnicero WHERE Correo = @email GROUP BY Nombre, id_Carnicero; ";
            string[] status = null;

            cnxTemp = Objacceso.AbrirConexion(ref m, ref i, ref t);
            SqlDataReader atrapa = null;
            atrapa = Objacceso.ConsultaDRP(q1, cnxTemp, ref m, ref i, ref t, pSQL);

            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    if ((int)atrapa[0] > 0)
                    {
                        status = new string[3];
                        status[0] = atrapa[0].ToString();
                        status[1] = atrapa[1].ToString();
                        status[2] = atrapa[2].ToString();

                        m = "Un momento";
                        t = "Ya estas registrado";
                        i = "success";
                    }
                    else
                    {
                        status = null;
                    }
                }
            }
            cnxTemp.Close();
            cnxTemp.Dispose();
            return status;
        }
        public DataTable PedidosGrid2(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT id_Pedido, FechaHora, Envio, Pago FROM Pedido WHERE F_Cliente = @idcli";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }



        public DataTable PedidosGrid3(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT id_prod, NombreProd, Peso, Cantidad, NotaEspecial, Nombre as Carnicero FROM Carnicero INNER JOIN Pedido ON Carnicero.id_Carnicero = Pedido.F_Carnicero INNER JOIN Producto ON Pedido.id_Pedido = Producto.F_Pedido WHERE F_Pedido = @idcli";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }


        public DataTable Pedidoscobroelrepartidor(ref string m, ref string i, ref string t)
        {
            string query2 = "SELECT Nombre, COUNT(SeEntrego) Efectivo, Pago FROM Repartidor INNER JOIN EntregaPedido ON Repartidor.id_Repartidor = EntregaPedido.F_Repartidor INNER JOIN Pedido ON EntregaPedido.F_Pedido = Pedido.id_Pedido WHERE Pago = 'Pago al recoger' GROUP BY Nombre, Pago";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDaSet(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }
        public DataTable Pedidosespachouncarnicero(ref string m, ref string i, ref string t)
        {
            string query2 = "SELECT Nombre, COUNT(id_Pedido) AS Pedidos FROM Carnicero INNER JOIN Pedido ON Pedido.F_Carnicero = Carnicero.id_Carnicero INNER JOIN EntregaPedido ON Pedido.id_Pedido = EntregaPedido.F_Pedido GROUP BY Nombre; ";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDaSet(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }

    }
}

