/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     26.06.2021 18:50:15                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('employee') and o.name = 'FK_EMPLOYEE_RELATIONS_POSITION')
alter table employee
   drop constraint FK_EMPLOYEE_RELATIONS_POSITION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('knowledge') and o.name = 'FK_KNOWLEDG_RELATIONS_COMPETEN')
alter table knowledge
   drop constraint FK_KNOWLEDG_RELATIONS_COMPETEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('knowledge') and o.name = 'FK_KNOWLEDG_RELATIONS_EMPLOYEE')
alter table knowledge
   drop constraint FK_KNOWLEDG_RELATIONS_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('requirement') and o.name = 'FK_REQUIREM_RELATIONS_POSITION')
alter table requirement
   drop constraint FK_REQUIREM_RELATIONS_POSITION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('requirement') and o.name = 'FK_REQUIREM_RELATIONS_COMPETEN')
alter table requirement
   drop constraint FK_REQUIREM_RELATIONS_COMPETEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('competence')
            and   type = 'U')
   drop table competence
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('employee')
            and   name  = 'Relationship_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index employee.Relationship_5_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('employee')
            and   type = 'U')
   drop table employee
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('knowledge')
            and   name  = 'Relationship_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index knowledge.Relationship_4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('knowledge')
            and   name  = 'Relationship_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index knowledge.Relationship_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('knowledge')
            and   type = 'U')
   drop table knowledge
go

if exists (select 1
            from  sysobjects
           where  id = object_id('position')
            and   type = 'U')
   drop table position
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('requirement')
            and   name  = 'Relationship_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index requirement.Relationship_2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('requirement')
            and   name  = 'Relationship_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index requirement.Relationship_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('requirement')
            and   type = 'U')
   drop table requirement
go

/*==============================================================*/
/* Table: competence                                            */
/*==============================================================*/
create table competence (
   id                   numeric              identity,
   name                 varchar(256)         not null,
   constraint PK_COMPETENCE primary key (id)
)
go

/*==============================================================*/
/* Table: employee                                              */
/*==============================================================*/
create table employee (
   id                   numeric              identity,
   pos_id               int                  null,
   fullname             varchar(256)         not null,
   constraint PK_EMPLOYEE primary key (id)
)
go

/*==============================================================*/
/* Index: Relationship_5_FK                                     */
/*==============================================================*/
create index Relationship_5_FK on employee (
pos_id ASC
)
go

/*==============================================================*/
/* Table: knowledge                                             */
/*==============================================================*/
create table knowledge (
   id                   numeric              identity,
   com_id               int                  null,
   emp_id               int                  null,
   level                int                  null,
   constraint PK_KNOWLEDGE primary key (id)
)
go

/*==============================================================*/
/* Index: Relationship_3_FK                                     */
/*==============================================================*/
create index Relationship_3_FK on knowledge (
com_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_4_FK                                     */
/*==============================================================*/
create index Relationship_4_FK on knowledge (
emp_id ASC
)
go

/*==============================================================*/
/* Table: position                                              */
/*==============================================================*/
create table position (
   id                   numeric              identity,
   name                 varchar(256)         not null,
   constraint PK_POSITION primary key (id)
)
go

/*==============================================================*/
/* Table: requirement                                           */
/*==============================================================*/
create table requirement (
   id                   numeric              identity,
   pos_id               int                  null,
   com_id               int                  null,
   level                int                  null,
   constraint PK_REQUIREMENT primary key (id)
)
go

/*==============================================================*/
/* Index: Relationship_1_FK                                     */
/*==============================================================*/
create index Relationship_1_FK on requirement (
pos_id ASC
)
go

/*==============================================================*/
/* Index: Relationship_2_FK                                     */
/*==============================================================*/
create index Relationship_2_FK on requirement (
com_id ASC
)
go

alter table employee
   add constraint FK_EMPLOYEE_RELATIONS_POSITION foreign key (pos_id)
      references position (id)
         on update cascade
go

alter table knowledge
   add constraint FK_KNOWLEDG_RELATIONS_COMPETEN foreign key (com_id)
      references competence (id)
         on update cascade on delete cascade
go

alter table knowledge
   add constraint FK_KNOWLEDG_RELATIONS_EMPLOYEE foreign key (emp_id)
      references employee (id)
         on update cascade on delete cascade
go

alter table requirement
   add constraint FK_REQUIREM_RELATIONS_POSITION foreign key (pos_id)
      references position (id)
         on update cascade on delete cascade
go

alter table requirement
   add constraint FK_REQUIREM_RELATIONS_COMPETEN foreign key (com_id)
      references competence (id)
         on update cascade on delete cascade
go

