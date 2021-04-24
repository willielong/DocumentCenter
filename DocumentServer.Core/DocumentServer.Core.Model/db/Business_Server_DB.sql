/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2021/4/23 16:10:53                           */
/*==============================================================*/


drop table if exists AccoutInfo;

drop table if exists Fields;

drop table if exists TableInfo;

drop table if exists Employee; 
drop table if exists PartTimeInfo;

drop table if exists Permission; 

drop table if exists RoleInfo;

drop table if exists RolePermission;

drop table if exists RolePersonInfo;
 

drop table if exists UnitInfo;

drop table if exists organization;

drop table if exists position;

/*==============================================================*/
/* Table: AccoutInfo                                            */
/*==============================================================*/
create table AccoutInfo
(
   autoId               int not null auto_increment,
   account              varchar(20) not null,
   password             varchar(20) not null,
   name                 varchar(20) not null,
   empid                int not null,
   enable               bit,
   language             int,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoId)
);

/*==============================================================*/
/* Table: Bb_Fields                                             */
/*==============================================================*/
create table Fields
(
   autoid               int not null auto_increment,
   fieldcode            varchar(50),
   fieldname            varchar(50),
   fieldenname          varchar(200),
   tablecode            varchar(50),
   controlsouces        varchar(50),
   fieldtype            int,
   controlstype         int,
   defaultvalue         varchar(2000),
   fieldlength          int,
   isrequired           bit,
   isinlay              bit,
   enable               bit,
   isdel                bit,
   sequence             decimal(8,2),
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

/*==============================================================*/
/* Table: Bb_TableInfo                                          */
/*==============================================================*/
create table TableInfo
(
   autoid               int not null auto_increment,
   cnname               varchar(100),
   enname               varchar(100),
   enable               bit,
   isdel                bit,
   sequence             decimal(8,2),
   issystem             bit,
   tablecode            varchar(20),
   grouptype            int,
   viewtype             int,
   isprimary            bit default 0,
   pktable              varchar(20) default '',
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   isflow               bit default 0,
   primary key (autoid)
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
   orgId                int,
   postionId            int,
   gender               int,
   age                  int,
   idcard               varchar(50),
   status               int,
   repoter              int,
   birthday             datetime,
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (empid)
);

/*==============================================================*/
/* Table: PartTimeInfo                                          */
/*==============================================================*/
create table PartTimeInfo
(
   autoid               int not null auto_increment,
   empid                int not null,
   postionid            int not null,
   orgid                int not null,
   enable               bit,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

/*==============================================================*/
/* Table: Permission                                            */
/*==============================================================*/
create table Permission
(
   autoid               int not null auto_increment,
   cnname               varchar(500) not null,
   enname               varchar(500),
   permissioncode       varchar(500) not null,
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);


/*==============================================================*/
/* Table: RoleInfo                                              */
/*==============================================================*/
create table RoleInfo
(
   autoid               int not null auto_increment,
   cnname               varchar(100),
   enname               varchar(100),
   code                 varchar(100),
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

/*==============================================================*/
/* Table: RolePermission                                        */
/*==============================================================*/
create table RolePermission
(
   autoid               int not null auto_increment,
   roleid               int,
   permissionid         int,
   enable               bit,
   modifdate            datetime,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   primary key (autoid)
);

/*==============================================================*/
/* Table: RolePersonInfo                                        */
/*==============================================================*/
create table RolePersonInfo
(
   autoid               int not null auto_increment,
   empid                int not null,
   roleid               int,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);
 

/*==============================================================*/
/* Table: UnitInfo                                              */
/*==============================================================*/
create table UnitInfo
(
   unitID               int not null auto_increment,
   unitcode             varchar(500),
   cnname               varchar(500),
   enname               varchar(500),
   parentId             int,
   unitaddress          varchar(500),
   legal                varchar(500),
   phone                varchar(500),
   contact              varchar(500),
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
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
   untid                int,
   phone                varchar(500),
   contact              varchar(500),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   enable               bit,
   primary key (orgid)
);

/*==============================================================*/
/* Table: position                                              */
/*==============================================================*/
create table position
(
   postionId            int not null auto_increment,
   postioncode          varchar(20),
   cnname               varchar(100),
   enname               varchar(100),
   orgId                int,
   orgtype              int,
   issupervisor         bit,
   ischarge             bit,
   jobgrade             int,
   enable               bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (postionId)
);


drop table if exists buttons_permission;

/*==============================================================*/
/* Table: buttons_permission                                    */
/*==============================================================*/
create table buttons_permission
(
   btnid                bigint,
   permissionid         int,
   autoid               int not null auto_increment,
   primary key (autoid)
);

drop table if exists buttons;

/*==============================================================*/
/* Table: buttons                                               */
/*==============================================================*/
create table buttons
(
   btnid                bigint,
   enname               varchar(200),
   cnname               varchar(200),
   icon                 varchar(200),
   style                varchar(200),
   tooltips             varchar(200),
   btncode              varchar(20),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   isuseflow            bit
);


drop table if exists menus;

/*==============================================================*/
/* Table: menus                                                 */
/*==============================================================*/
create table menus
(
   menuid               bigint not null,
   code                 varchar(20),
   cnname               varchar(20),
   enname               varchar(20),
   address              text,
   icon                 varchar(20),
   parentcode           varchar(20),
   status               bit,
   sequence             double,
   creator              int,
   creatdate            datetime,
   primary key (menuid)
);
drop table if exists Menus_Roles;

/*==============================================================*/
/* Table: Menus_Roles                                           */
/*==============================================================*/
create table Menus_Roles
(
   menuid               bigint not null,
   roleid               int,
   status               bit,
   sequence             double,
   creator              int,
   creatdate            datetime,
   primary key (menuid)
);

