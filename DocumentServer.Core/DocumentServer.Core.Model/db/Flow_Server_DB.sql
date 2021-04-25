drop table if exists flowinfo;

/*==============================================================*/
/* Table: flowinfo                                              */
/*==============================================================*/
create table flowinfo
(
   flowid               bigint not null,
   cnname               text,
   enname               text,
   type                 bigint,
   manager              int,
   instancemanager      int,
   formid               bigint,
   isselectapplyemp     bit,
   ifloecon             text,
   flowstyle            text,
   promptmessage        text,
   skiprules            int,
   issendmessage        bit,
   status               bit,
   sequence             double,
   creator              int,
   installuser          int,
   creatdate            datetime,
   installdate          datetime,
   primary key (flowid)
);

drop table if exists flow_lines;

/*==============================================================*/
/* Table: flow_lines                                            */
/*==============================================================*/
create table flow_lines
(
   lineid               bigint not null,
   cnname               varchar(200),
   enname               varchar(200),
   formstep             bigint,
   tostep               bigint,
   businesscondition    text,
   personcondtion       text,
   orgcondtion          text,
   postioncondtion      text,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (lineid)
);

drop table if exists flow_version;

/*==============================================================*/
/* Table: flow_version                                          */
/*==============================================================*/
create table flow_version
(
   versionid            bigint not null,
   flowid               bigint,
   name                 varchar(32),
   versionno            double(16,2),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (versionid)
);
drop table if exists flow_step;

/*==============================================================*/
/* Table: flow_step                                             */
/*==============================================================*/
create table flow_step
(
   stepid               bigint,
   cnnmae               varchar(200),
   enname               varchar(200),
   steptype             int comment '1、正常步骤
            2、子流程',
   isautoselectsep      bit,
   strategytype         int,
   approveparttimepostion int,
   sendparttimepostion  int,
   approvertype         int,
   formfield            text,
   formfieldapprovetype int,
   isfirststep          bit,
   isendstep            bit,
   parentstep           bigint,
   appoverrange         text,
   defaultapprover      int,
   disposetype          int,
   isdisplayhositry     bit,
   isopinion            bit,
   opinionrequired      bit,
   coordinate_x         int,
   coordinate_y         int,
   isskipstep           bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime
);

drop table if exists flow_step_form_fields;

/*==============================================================*/
/* Table: flow_step_form_fields                                 */
/*==============================================================*/
create table flow_step_form_fields
(
   stepid               bigint not null,
   flowid               bigint,
   formid               bigint,
   fieldkey             varchar(512),
   cnname               varchar(200),
   enname               varchar(200),
   display              bit,
   editor               bit,
   required             bit,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (stepid)
);

drop table if exists flow_buttons;

/*==============================================================*/
/* Table: flow_buttons                                          */
/*==============================================================*/
create table flow_buttons
(
   stepid               bigint,
   flowid               bigint,
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
   modifdate            datetime
);
drop table if exists flow_instance;

/*==============================================================*/
/* Table: flow_instance                                         */
/*==============================================================*/
create table flow_instance
(
   instanceid           bigint not null,
   businessid           int,
   flowid               bigint,
   formid               bigint,
   formversionid        bigint,
   flowversionid        bigint,
   initiatorempid       int,
   applyempid           int,
   currentsteptitle     text,
   currentstep          bigint,
   flowstatus           int,
   applydate            datetime,
   initiatordate        datetime,
   primary key (instanceid)
);

drop table if exists flow_task;

/*==============================================================*/
/* Table: flow_task                                             */
/*==============================================================*/
create table flow_task
(
   instanceid           bigint,
   taskid               bigint not null,
   title                text,
   prevtaskid           bigint,
   stepid               bigint,
   prevstepid           bigint,
   reviewer             int,
   sender               int,
   receivingtime        datetime,
   processtime          datetime,
   status               int,
   type                 int,
   comment              text,
   sort                 int,
   mandator             int,
   isread               bit,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (taskid)
);

drop table if exists flow_icon;

/*==============================================================*/
/* Table: flow_icon                                             */
/*==============================================================*/
create table flow_icon
(
   cnname               varchar(20),
   enname               varchar(20),
   icon                 varchar(20),
   background           varchar(20),
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime
);

drop table if exists flow_line_filter;

/*==============================================================*/
/* Table: flow_line_filter                                      */
/*==============================================================*/
create table flow_line_filter
(
   formid               bigint,
   formversionid        bigint,
   fileldkey            text,
   fieldtype            int,
   selecttype           int,
   paramterid           varchar(200),
   sequence             double,
   creator              int,
   creatdate            datetime
);

drop table if exists delegationinfo;

/*==============================================================*/
/* Table: delegationinfo                                        */
/*==============================================================*/
create table delegationinfo
(
   autoid               int not null auto_increment,
   fromemp              int,
   toemp                int,
   starttime            datetime,
   endtime              datetime,
   sequence             double,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime,
   primary key (autoid)
);

drop table if exists deleteonflowtypes;

/*==============================================================*/
/* Table: deleteonflow                                          */
/*==============================================================*/
create table deleteonflowtypes
(
   delegetid            int,
   flowtype             bigint,
   creator              int,
   modifier             int,
   creatdate            datetime,
   modifdate            datetime
);

