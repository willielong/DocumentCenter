drop table if exists FileFloder;

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

drop table if exists Files;

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

drop table if exists FilesVersion;

/*==============================================================*/
/* Table: FilesVersion                                          */
/*==============================================================*/
create table FilesVersion
(
   autoid               int not null auto_increment,
   filekey              text not null,
   version              int not null,
   serverVersion        varchar(20),
   changes              text,
   prevuri              text,
   changesUrl           text,
   fileid               int not null,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

drop table if exists Physicalhistory;

/*==============================================================*/
/* Table: Physicalhistory                                       */
/*==============================================================*/
create table Physicalhistory
(
   autoid               int not null auto_increment,
   physicalfolder       text not null,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   primary key (autoid)
);