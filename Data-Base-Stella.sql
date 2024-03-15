/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     30/08/2021 04:36:24 p. m.                    */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACTIVIDAD') and o.name = 'FK_ACTIVIDA_REFERENCE_USUARIO')
alter table ACTIVIDAD
   drop constraint FK_ACTIVIDA_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACTIVIDAD') and o.name = 'FK_ACTIVIDA_REFERENCE_TIPOUSUA')
alter table ACTIVIDAD
   drop constraint FK_ACTIVIDA_REFERENCE_TIPOUSUA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CONSULTA') and o.name = 'FK_CONSULTA_REFERENCE_USUARIO')
alter table CONSULTA
   drop constraint FK_CONSULTA_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EJERCICIO') and o.name = 'FK_EJERCICI_REFERENCE_ACTIVIDA')
alter table EJERCICIO
   drop constraint FK_EJERCICI_REFERENCE_ACTIVIDA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDALLA') and o.name = 'FK_MEDALLA_REFERENCE_USUARIO')
alter table MEDALLA
   drop constraint FK_MEDALLA_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDALLA') and o.name = 'FK_MEDALLA_REFERENCE_ACTIVIDA')
alter table MEDALLA
   drop constraint FK_MEDALLA_REFERENCE_ACTIVIDA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESPUESTA') and o.name = 'FK_RESPUEST_REFERENCE_CONSULTA')
alter table RESPUESTA
   drop constraint FK_RESPUEST_REFERENCE_CONSULTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACTIVIDAD')
            and   type = 'U')
   drop table ACTIVIDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CONSULTA')
            and   type = 'U')
   drop table CONSULTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EJERCICIO')
            and   type = 'U')
   drop table EJERCICIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEDALLA')
            and   type = 'U')
   drop table MEDALLA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RESPUESTA')
            and   type = 'U')
   drop table RESPUESTA
go


if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ACTIVIDAD                                             */
/*==============================================================*/
create table ACTIVIDAD (
   ID_ACTIVIDAD         int                  identity not null,
   TITULO               varchar(100)         null,
   DESCRIPCION          varchar(Max)         null,
   IMAGEN               image                null,
   NUMENUNCIADOS        int                  null,
   ID_USUARIO           varchar(20)          null,
   constraint PK_ACTIVIDAD primary key nonclustered (ID_ACTIVIDAD)
)
go

/*==============================================================*/
/* Table: CONSULTA                                              */
/*==============================================================*/
create table CONSULTA (
   ID_CONSULTA          int                  identity not null,
   ID_USUARIO           varchar(20)          null,
   TITULO               varchar(100)         null,
   DIACONS              int                  null,
   MESCONS              int                  null,
   ANIOCONS             int                  null,
   CONTENIDO            varchar(Max)         null,
   constraint PK_CONSULTA primary key nonclustered (ID_CONSULTA)
)
go

/*==============================================================*/
/* Table: EJERCICIO                                             */
/*==============================================================*/
create table EJERCICIO (
   ID_EJERCICIO         int                  identity not null,
   ID_ACTIVIDAD         int                  null,
   ILUSTRATIVO          image                null,
   ENUNCIADO            varchar(250)         null,
   T_OPTION             varchar(100)         null,
   F1_OPTION            varchar(100)         null,
   F2_OPTION            varchar(100)         null,
   F3_OPTION            varchar(100)         null,
   constraint PK_EJERCICIO primary key nonclustered (ID_EJERCICIO)
)
go

/*==============================================================*/
/* Table: MEDALLA                                               */
/*==============================================================*/
create table MEDALLA (
   ID_MEDALLA           int                  identity not null,
   TIPOMEDALLA          varchar(20)          null,
   ID_USUARIO           varchar(20)          null,
   ID_ACTIVIDAD         int                  null,
   constraint PK_MEDALLA primary key nonclustered (ID_MEDALLA)
)
go

/*==============================================================*/
/* Table: RESPUESTA                                             */
/*==============================================================*/
create table RESPUESTA (
   ID_RESPUESTA         int                  identity not null,
   ID_CONSULTA          int                  null,
   ID_USUARIO           varchar(20)          null,
   CONTENIDO            varchar(500)         null,
   DIARESP              int                  null,
   MESRESP              int                  null,
   ANIORESP             int                  null,
   constraint PK_RESPUESTA primary key nonclustered (ID_RESPUESTA)
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           varchar(20)          not null,
   PAIS                 varchar(40)          null,
   CORREO               varchar(Max)         null,
   NOMBRE               varchar(30)          null,
   APELLIDO             varchar(30)          null,
   CONTRASENIA          varchar(20)          null,
   DIAINICIO            int                  null,
   MESINICIO            int                  null,
   ANIOINICIO           int                  null,
   DESCRIPCION          varchar(Max)          null,
   FOTOPERFIL           image                null,
   MEDALLA1             int                  null,
   MEDALLA2             int                  null,
   MEDALLA3             int                  null,
   TIPOUSUARIO          varchar(20)          null,
   constraint PK_USUARIO primary key nonclustered (ID_USUARIO)
)
go

alter table ACTIVIDAD
   add constraint FK_ACTIVIDA_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table CONSULTA
   add constraint FK_CONSULTA_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table EJERCICIO
   add constraint FK_EJERCICI_REFERENCE_ACTIVIDA foreign key (ID_ACTIVIDAD)
      references ACTIVIDAD (ID_ACTIVIDAD)
go

alter table MEDALLA
   add constraint FK_MEDALLA_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table MEDALLA
   add constraint FK_MEDALLA_REFERENCE_ACTIVIDA foreign key (ID_ACTIVIDAD)
      references ACTIVIDAD (ID_ACTIVIDAD)
go

alter table RESPUESTA
   add constraint FK_RESPUEST_REFERENCE_CONSULTA foreign key (ID_CONSULTA)
      references CONSULTA (ID_CONSULTA)
go


