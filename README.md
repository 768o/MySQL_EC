# MySQL_EC
MySQL_EC基于MYSQL数据库的只支持简单SQL操作的的插件

## 优点
1.把SQL语句简单化，可以快速得得到我们需要的SQL语句<BR>
2.比起传统方法，支持批量处理语句，易于测试

## 缺点
1.暂时不支持复杂的sql语句,需要配合视图使用<BR>
2.功能少

## 功能

#### 1.添加数据
添加了 id number table 分别为 1 table 77 的数据。<BR>
<pre><code>
List<SQLRequirement> update = new List<SQLRequirement> {
    new SQLRequirement{ Field = "id", Value = "1" },
    new SQLRequirement{ Field = "number", Value = "'table'" },
    new SQLRequirement{ Field = "table", Value = "77" },
};
int b = service.Insert("table",update);
</code></pre>
#### 2.删除数据
删除了id=1 and number = 1 的项。<BR>
<pre><code>
List<SQLRequirement> delete = new List<SQLRequirement> {
    new SQLRequirement{ Field = "id", Mode = "=", Value = "1"},
    new SQLRequirement{ Field = "nunber", Mode = "=", Value = "1" },
};
int c = service.Delete("table", delete);
</code></pre>
#### 3.修改数据
把id=1的项中的number设置成2<BR>
<pre><code>
List<SQLRequirement> update_where = new List<SQLRequirement> {
    new SQLRequirement{ Field = "id", Mode = "=", Value = "1" },
};
    List<SQLRequirement> update_set = new List<SQLRequirement> {
    new SQLRequirement{ Field = "number", Mode = "=", Value = "2" },
    };
int d = service.Update("table", update_set, update_where);
</code></pre>
#### 4.查询数据
相当于 select id,number,name from table where id like '%1%' and number = 2;<BR>
List<SQLRequirement> select = new List<SQLRequirement> {
    new SQLRequirement{ Field = "id",Mode = "like", Value = "1" },
    new SQLRequirement{ Field = "number",Mode = "=", Value = "2" },
};
string a = service.Select("table", select,"id,number,name");
##### 配置数据库 app.config 设置
<pre><code>&lt;appSettings&gt;
&lt;add key="conn" value="server=server;Database=Database;User Id=Id;Password=Password"&gt;
&lt;/appSettings&gt;
</code></pre>


