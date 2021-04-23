drop table if exists MainForm;

/*==============================================================*/
/* Table: MainForm                                              */
/*==============================================================*/
create table MainForm
(
   formid               bigint not null,
   cnname               varchar(100),
   enname               varchar(100),
   status               int,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (formid)
);

drop table if exists form_version;

/*==============================================================*/
/* Table: form_version                                          */
/*==============================================================*/
create table form_version
(
   versionid            bigint not null,
   formid               bigint not null,
   name                 varchar(20),
   versionno            int not null,
   forms                text,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (versionid)
);


drop table if exists form_business_table;

/*==============================================================*/
/* Table: form_business_table                                   */
/*==============================================================*/
create table form_business_table
(
   autoid               int not null auto_increment,
   versionid            bigint not null,
   tablecode            varchar(200),
   primarykey           varchar(200),
   ismaintable          bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);
