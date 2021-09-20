﻿<summary>
1 O/RM对象关系映射
2 EntityFramework DBFirst
3 EntityFramework codeFirst from db &&codeFirst 
4 EntityFramework modelFirst
5 EF增删改查基本实现


环境说明：在之前导入的数据库上，执行user-role-menu-log.sql即可

O/RM--EF6 
O/RM--对象关系映射：是一种数据访问的封装

EntityFramework6:支持多数据库；支持函数，存储过程；跟VS集合的好；跟项目完美结合；
   context---映射数据库实例
   实体类----映射表
   
DBFirst:数据库优先，传统的开发模式，有个很重的edmx
CodeFirst:代码先行，不关心数据库，从业务出发，然后能自动生成数据库
CodeFirstFromDB:

EF查看SQL2种方式  
1 sqlprofiler   
2  context.Database.Log += s => Console.WriteLine($"当前执行sql:{s}");

映射：
1 特性映射
2 OnModelCreating完成链式映射
3 映射类文件



1 各种复杂查询&直接执行sql
2 EF状态跟踪，本地增删改实现


封装类库--上端引用--引用EF--搬迁配置文件
各种复杂查询--show
EF还可以直接执行sql语句-事务，跟ado.net差不多


1 Context生命周期，多种事务
2 EF延迟查询、导航属性加载&增加&删除


事务：1 SaveChange  
      2 TransactionScope完成一个context的多次SaveChange
      3 TransactionScope完成不同context实例的事务
      4 通过context.Datebase.BeginTranscation