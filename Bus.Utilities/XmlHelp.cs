using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bus.Utilities
{
    public class XmlHelp
    {
        /// <summary>
        ///     ''' Devuelve en un DataTable una parte de la estructura de un xml.
        ///     ''' </summary>
        ///     ''' <param name="oXml">XML</param>
        ///     ''' <param name="NameTableNode">Lista de Entidades de la estructura XML de donde se leera, ej: DatosPacientes.</param>
        ///     ''' <param name="NameEntidadNode">Entidad de la estructura XML, ej: DatoPaciente</param>
        ///     ''' <param name="columns">Propiedades de la Entidad, ej: CodPaciente, Nombres, DocIdentidad, etc.</param>
        ///     ''' <returns></returns>
        public static DataTable DevolverTabla_XML(XmlDocument oXml, string NameTableNode, string NameEntidadNode, params string[] columns)
        {
            DataTable dt = new DataTable();
            int i = 0;
            
            if (columns[0] == "td")
            {
                for (i = 0; i <= columns.LongLength - 1; i++)
                    dt.Columns.Add(columns[i] + i.ToString());
            }
            else
                for (i = 0; i <= columns.LongLength - 1; i++)
                    dt.Columns.Add(columns[i]);

            DataRow rows;
            XmlNodeList nodes = oXml.SelectNodes("//" + NameTableNode);

            foreach (XmlNode childrenNodes in nodes)
            {
                XmlNodeList nodes2 = childrenNodes.SelectNodes(NameEntidadNode);

                foreach (XmlNode childrenNodes2 in nodes2)
                {
                    rows = dt.NewRow();

                    if ((columns[0] == "td"))
                    {
                        for (i = 0; i <= columns.LongLength - 1; i++)
                            rows[i] = childrenNodes2.SelectNodes(columns[0]).Item(i).InnerText;
                    }
                    else
                        for (i = 0; i <= columns.LongLength - 1; i++)
                            rows[columns[i]] = childrenNodes2.SelectNodes(columns[i]).Item(0).InnerText;
                    dt.Rows.Add(rows);
                }
            }

            return dt;
        }
    }
}