


class Curd:

        def __init__(self,dbname,tbName):
                self.conn = sqlite3.connect(dbname)
                self.c = self.conn.cursor()
                self.Table = tbName

        def createTable(self,table_name,cols):
                cmd1= " create " +  table_name + "("
                for c in cols:
                        cmd1 += "{} {},".format(c,cols[c])
                cmd1 += ")"
                #return("create {} person(name TEXT)".format(table_name))
                return cmd1

        def insertTable(self,name):
                return("Insert into person(name) Value({})".format(name))

        def Execute(self,cmd_txt):
                self.c.execute(cmd_txt)
                self.conn.commit();

#d = CRUD("person.sqlite")
#d.createTable()





