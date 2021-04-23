drop table if exists TenantInformation;

/*==============================================================*/
/* Table: TenantInformation                                     */
/*==============================================================*/
create table TenantInformation
(
   autoid               int not null auto_increment,
   cnnme                varchar(200),
   phone                varchar(200),
   code                 varchar(200),
   dbconnection         text,
   enable               bit,
   wf_dbconnection      text,
   wf_form_dbconnection text,
   files_dbconnection   text,
   creatdate            datetime,
   expirationdate       datetime,
   primary key (autoid)
);
