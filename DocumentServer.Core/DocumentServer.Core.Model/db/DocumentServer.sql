drop table if exists AccoutInfo;

drop table if exists Employee;

drop table if exists FileFloder;

drop table if exists Files;

drop table if exists FilesVersion;

drop table if exists Physicalhistory;

drop table if exists UnitInfo;

drop table if exists organization;

/*==============================================================*/
/* Table: AccoutInfo                                            */
/*==============================================================*/
create table AccoutInfo
(
   autoId               int not null auto_increment,
   account              varchar(20) not null,
   password             varchar(20) not null,
   name                 varchar(20) not null,
   email                varchar(200) not null,
   phone                varchar(20),
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   sequence             double,
   empid                int not null,
   primary key (autoId)
);

/*==============================================================*/
/* Table: Employee                                              */
/*==============================================================*/
create table Employee
(
   empid                int not null auto_increment,
   cnname               varchar(20) not null,
   enname               varchar(100) not null,
   empcode              varchar(20) not null,
   email                varchar(100) not null,
   phone                varchar(20),
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   orgId                int,
   primary key (empid)
);

/*==============================================================*/
/* Table: FileFloder                                            */
/*==============================================================*/
create table FileFloder
(
   autoId               int not null auto_increment,
   parentId             int not null,
   cnname               text not null,
   enname               text not null,
   path                 text not null,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   sequence             double,
   flodertype           int,
   orgid                int,
   primary key (autoId)
);

/*==============================================================*/
/* Table: Files                                                 */
/*==============================================================*/
create table Files
(
   autoid               int not null auto_increment,
   cnname               text,
   enname               text,
   folderid             int,
   ext                  varchar(10),
   filetype             varchar(10),
   fileuri              text,
   filepath             text,
   path                 text,
   size                 double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   sequence             double,
   currentVersion       int,
   folderpath           text,
   primary key (autoid)
);

/*==============================================================*/
/* Table: FilesVersion                                          */
/*==============================================================*/
create table FilesVersion
(
   autoid               int not null auto_increment,
   filekey              text not null,
   version              int not null,
   serverVersion        varchar(20),
   changes              varchar(500),
   prevuri              text,
   changesUrl           text,
   fileid               int not null,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

/*==============================================================*/
/* Table: Physicalhistory                                       */
/*==============================================================*/
create table Physicalhistory
(
   autoid               int not null auto_increment,
   physicalfolder       int not null,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   primary key (autoid)
);

/*==============================================================*/
/* Table: UnitInfo                                              */
/*==============================================================*/
create table UnitInfo
(
   unitID               int not null auto_increment,
   unitcode             varchar(20),
   cnname               varchar(100),
   enname               varchar(100),
   parentId             int,
   head                 int,
   c_head               varchar(20),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   primary key (unitID)
);

/*==============================================================*/
/* Table: organization                                          */
/*==============================================================*/
create table organization
(
   orgid                int not null auto_increment,
   orgcode              varchar(20),
   cnname               varchar(100),
   enname               varchar(100),
   parentId             int,
   head                 int,
   c_head               varchar(20),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   isvirorg             bit,
   istree               bit,
   untid                int,
   primary key (orgid)
);

drop table if exists Bb_TableInfo;

/*==============================================================*/
/* Table: Bb_TableInfo                                          */
/*==============================================================*/
create table Bb_TableInfo
(
   autoid               int not null auto_increment,
   cnname               varchar(100) default(''),
   enname               varchar(100) default(''),
   enable               bit default(0),
   isdel                bit default(0),
   sequence             decimal(8,2) default(0.00),
   issystem             bit default(0),
   tablecode            varchar(20) not null,
   grouptype            int default(-1),
   viewtype             int default(-1),
   isprimary            bit default(0),
   pktable              varchar(20) default (''),
   creator              int default(-1),
   modifier             int default(-1),
   creatdate            datetime default('1000-01-01 00:00:00'),
   modifdate            datetime default('1000-01-01 00:00:00'),
   primary key (autoid)
);

drop table if exists Bb_Fields;

/*==============================================================*/
/* Table: Bb_Fields                                             */
/*==============================================================*/
create table Bb_Fields
(
   autoid               int not null auto_increment,
   fieldcode            varchar(50) not null,
   fieldname            varchar(50)  not null,
   fieldenname          varchar(200) default(''),
   tablecode            varchar(50)  not null,
   controlsouces        varchar(50) default(''),
   fieldtype            int default(-1),
   controlstype         int default(-1),
   defaultvalue         varchar(2000) default(''),
   fieldlength          int default(-1),
   isrequired           bit default(0),
   isinlay              bit default(0),
   enable               bit default(0),
   isdel                bit default(0),
   sequence             decimal(8,2) default(0.00),
   creator              int default(-1),
   modifier             int default(-1),
   creatdate            datetime default('1000-01-01 00:00:00'),
   modifdate            datetime default('1000-01-01 00:00:00'),
   primary key (autoid)
);
