using ReporteKMS.DAL;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.BL.Catalogos
{
    public class CargaInicial
    {
        public void Inicio()
        {
            DAOArea daoArea = new DAOArea();
            var consulArea = daoArea.ObtenerTodo();
            if (consulArea.Count == 0) {
                List<ModeloArea> areas = new List<ModeloArea>() {
                new ModeloArea() { Activo= true, Area= "Desarrollo" },
                new ModeloArea() { Activo= true, Area= "Pruebas" }
            };
                daoArea.AgregarMuchos(areas);
            }


            DAOAplicativo daoAplicativo = new DAOAplicativo();
            var consulAp = daoAplicativo.ObtenerTodo();
            if (consulAp.Count == 0)
            {
                ModelAplicativo aplicativo = new ModelAplicativo() { Activo = true, Aplicativo = "KMS" };
                daoAplicativo.Agregar(aplicativo);
            }
            DAOEstatusCP daoEstatus = new DAOEstatusCP();
            var consulEstatus = daoEstatus.ObtenerTodo();
            if (consulEstatus.Count == 0) {
                List<ModeloEstatusCP> estatus = new List<ModeloEstatusCP>() {
                new ModeloEstatusCP(){ Activo= true, Estatus= "Pendiente a ejecutar" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "Ejecutados exitosamente" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "Incidencia-Pendiente de corrección" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "Mejora" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "En corrección desarrollo" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "Corregido Desarrollo" },
                new ModeloEstatusCP(){ Activo= true, Estatus= "No aplica" }
            };
                daoEstatus.AgregarMuchos(estatus);
            }
            var objectIdApp = daoAplicativo.ObtenerTodo()[0].Id;
            DAOModulo daoModulo = new DAOModulo();
            var consulModulo = daoModulo.ObtenerTodo();
            if (consulModulo.Count == 0)
            {
                if (objectIdApp != null)
                {
                    List<ModeloModulo> modulos = new List<ModeloModulo>() {
                       new ModeloModulo() { Activo = true, idAplicativo = objectIdApp, Modulo = "Seguridad"},
                       new ModeloModulo() { Activo = true, idAplicativo = objectIdApp, Modulo = "Contrato"}
                    };
                    daoModulo.AgregarMuchos(modulos);
                }
            }
            DAOSeccion daoSeccion = new DAOSeccion();
            var consulSeccion = daoSeccion.ObtenerTodo();

            ///////////////////////////////////////////
            ///
            //daoModulo.Agregar(new ModeloModulo() { Activo = true, idAplicativo = objectIdApp, Modulo = "Extension de contrato" });
            //consulModulo = daoModulo.ObtenerTodo();
            //var idContrato2 = consulModulo.Where(x => x.Modulo.Equals("Autorizacion de contrato")).FirstOrDefault().Id;
            //List<ModeloSeccion> seccionesSeguridad2 = new List<ModeloSeccion>() {
            //         new ModeloSeccion() { IdModulo= idContrato2, Seccion="Filtros Autorizacion de contrato", Activo= true },
            //         new ModeloSeccion() { IdModulo= idContrato2, Seccion="Autorizacion de contrato", Activo= true }
            //    };
            //daoSeccion.AgregarMuchos(seccionesSeguridad2);

            ///////////////////////////////////////////

            if (consulSeccion.Count == 0)
            {
                consulModulo = daoModulo.ObtenerTodo();
                var idSeguridad = consulModulo.Where(x => x.Modulo.Equals("Seguridad")).FirstOrDefault().Id;
                var idContrato = consulModulo.Where(x => x.Modulo.Equals("Contrato")).FirstOrDefault().Id;
                List<ModeloSeccion> seccionesSeguridad = new List<ModeloSeccion>() {
                     new ModeloSeccion() { IdModulo= idSeguridad, Seccion="Recuperación de contraseña", Activo= true },
                     new ModeloSeccion() { IdModulo= idSeguridad, Seccion="Cambio de contraseña", Activo= true }
                };
                daoSeccion.AgregarMuchos(seccionesSeguridad);
                List<ModeloSeccion> seccionesContrato = new List<ModeloSeccion>() {
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Filtros y datos generales", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Servicio/Tipo de Servicio/Proveedor/Fase", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Aplicativo/Proyecto", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Responsables del aplicativo/proyecto", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Perfiles técnicos", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Niveles de servicio", Activo= true },
                     new ModeloSeccion() { IdModulo= idContrato, Seccion="Extensión de contrato", Activo= true }
                };
                daoSeccion.AgregarMuchos(seccionesContrato);
            }

            DAOPersonal daoPersonal = new DAOPersonal();
            var consulPersonal = daoPersonal.ObtenerTodo();
            if (consulPersonal.Count == 0)
            {
                consulArea = daoArea.ObtenerTodo();
                var idDesarrollo = consulArea.Where(x => x.Area.Equals("Desarrollo")).FirstOrDefault().Id;
                var idPruebas = consulArea.Where(x => x.Area.Equals("Pruebas")).FirstOrDefault().Id;
                List<ModeloPersonal> personalDesarrollo = new List<ModeloPersonal>()
                {
                     new ModeloPersonal() { Activo= true, Correo="alam.vazquez@kriosoft.com", IdArea= idDesarrollo, Personal="Alam Vazquez Ibarra" },
                     new ModeloPersonal() { Activo= true, Correo="jose.juarez@kriosoft.com", IdArea= idDesarrollo, Personal="Jose Ma Juarez" },
                     new ModeloPersonal() { Activo= true, Correo="luis.bascocelos@kriosoft.com", IdArea= idDesarrollo, Personal="Luis Basconcelos" },
                     new ModeloPersonal() { Activo= true, Correo="veronica.cruz@kriosoft.com", IdArea= idDesarrollo, Personal="Veronica Cruz" },
                     new ModeloPersonal() { Activo= true, Correo="eduardo.jimenez@kriosoft.com", IdArea= idDesarrollo, Personal="Eduardo Jiménez" },
                     new ModeloPersonal() { Activo= false, Correo="israel.alquicira@kriosoft.com", IdArea= idDesarrollo, Personal="Israel Alquicira" },
                     new ModeloPersonal() { Activo= false, Correo="daniel.beltran@kriosoft.com", IdArea= idDesarrollo, Personal="Daniel Beltrán" }
                };
                daoPersonal.AgregarMuchos(personalDesarrollo);
                List<ModeloPersonal> personalQA = new List<ModeloPersonal>()
                {
                     new ModeloPersonal() { Activo= true, Correo="alejandra.carrera@kriosoft.com", IdArea= idPruebas, Personal="Alejandra Carrera" },
                     new ModeloPersonal() { Activo= true, Correo="vanessa.gomez@kriosoft.com", IdArea= idPruebas, Personal="Vanessa Gómez" },
                     new ModeloPersonal() { Activo= true, Correo="eva.orduna@kriosoft.com", IdArea= idPruebas, Personal="Eva Orduna" }
                };
                daoPersonal.AgregarMuchos(personalQA);
            }

            DAOCasosPrueba daoCasosPrueba = new DAOCasosPrueba();
            var consulCasosPrueba = daoCasosPrueba.ObtenerTodo();
            if (consulCasosPrueba.Count == 0)
            {
                List<ModeloCasosPrueba> ListCPDatosGenerales = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 91; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal= consulPersonal.Where(x => x.Correo.Equals("alejandra.carrera@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Filtros y datos generales")).FirstOrDefault().Id;
                    ListCPDatosGenerales.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        FechaEstimadaInicio = DateTime.Parse("04/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("17/10/2019"),
                        IdSeccion= idSeccion,
                        seccion = "Filtros y datos generales"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales);

                List<ModeloCasosPrueba> ListCPDatosGenerales2 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 66; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("vanessa.gomez@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Servicio/Tipo de Servicio/Proveedor/Fase")).FirstOrDefault().Id;
                    ListCPDatosGenerales2.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("04/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("17/10/2019"),
                        seccion = "Servicio/Tipo de Servicio/Proveedor/Fase"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales2);

                List<ModeloCasosPrueba> ListCPDatosGenerales3 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 58; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("eva.orduna@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Aplicativo/Proyecto")).FirstOrDefault().Id;
                    ListCPDatosGenerales3.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("04/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("10/10/2019"),
                        seccion = "Aplicativo/Proyecto"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales3);

                List<ModeloCasosPrueba> ListCPDatosGenerales4 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 64; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("eva.orduna@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Responsables del aplicativo/proyecto")).FirstOrDefault().Id;
                    ListCPDatosGenerales4.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("10/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("17/10/2019"),
                        seccion = "Responsables del aplicativo/proyecto"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales4);


                List<ModeloCasosPrueba> ListCPDatosGenerales5 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 48; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("vanessa.gomez@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Perfiles técnicos")).FirstOrDefault().Id;
                    ListCPDatosGenerales5.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("18/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Perfiles técnicos"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales5);

                List<ModeloCasosPrueba> ListCPDatosGenerales6 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 52; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("alejandra.carrera@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Niveles de servicio")).FirstOrDefault().Id;
                    ListCPDatosGenerales6.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("18/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Niveles de servicio"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales6);

                List<ModeloCasosPrueba> ListCPDatosGenerales7 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 58; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("eva.orduna@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Extensión de contrato")).FirstOrDefault().Id;
                    ListCPDatosGenerales7.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("18/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("23/10/2019"),
                        seccion = "Extensión de contrato"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales7);

                List<ModeloCasosPrueba> ListCPDatosGenerales8 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 20; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("vanessa.gomez@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Filtros Autorizacion de contrato")).FirstOrDefault().Id;
                    ListCPDatosGenerales8.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("17/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Filtros Autorizacion de contrato"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales8);

                List<ModeloCasosPrueba> ListCPDatosGenerales9 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 20; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("vanessa.gomez@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Autorizacion de contrato")).FirstOrDefault().Id;
                    ListCPDatosGenerales9.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("17/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Autorizacion de contrato"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales9);

                List<ModeloCasosPrueba> ListCPDatosGenerales10 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 6; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("eva.orduna@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Recuperación de contraseña")).FirstOrDefault().Id;
                    ListCPDatosGenerales10.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("24/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Recuperación de contraseña"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales10);

                List<ModeloCasosPrueba> ListCPDatosGenerales11 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 8; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("eva.orduna@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Cambio de contraseña")).FirstOrDefault().Id;
                    ListCPDatosGenerales11.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("24/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Cambio de contraseña"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales11);

                List<ModeloCasosPrueba> ListCPDatosGenerales12 = new List<ModeloCasosPrueba>();
                for (int a = 1; a <= 23; a++)
                {
                    string cpName = String.Empty;
                    if (a <= 9)
                        cpName = "CP0" + a.ToString();
                    else
                        cpName = "CP" + a.ToString();
                    consulPersonal = daoPersonal.ObtenerTodo();
                    var idPersonal = consulPersonal.Where(x => x.Correo.Equals("vanessa.gomez@kriosoft.com")).FirstOrDefault().Id;
                    consulEstatus = daoEstatus.ObtenerTodo();
                    var idEstatus = consulEstatus.Where(x => x.Estatus.Equals("Pendiente a ejecutar")).FirstOrDefault().Id;
                    consulSeccion = daoSeccion.ObtenerTodo();
                    var idSeccion = consulSeccion.Where(x => x.Seccion.Equals("Entregables Tipo de servicio - Fase")).FirstOrDefault().Id;
                    ListCPDatosGenerales12.Add(new ModeloCasosPrueba()
                    {
                        CasoPrueba = cpName,
                        Ciclo = 1,
                        persoanlEje = idPersonal,
                        IdEstatus = idEstatus,
                        IdSeccion = idSeccion,
                        FechaEstimadaInicio = DateTime.Parse("17/10/2019"),
                        FechaEstimadaFin = DateTime.Parse("24/10/2019"),
                        seccion = "Entregables Tipo de servicio -Fase"
                    });
                }
                daoCasosPrueba.AgregarMuchos(ListCPDatosGenerales12);
                
            }
        }
    }
}