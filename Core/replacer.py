

INPUT= "kestrel.json"
OUTPUT ="appsettings.json"
REPLACER = "///#ToReplace"

def replace( input:str, output:str  ) -> bool :

    try:
        strInput  = open(input, 'r').read()
        strOutPut = open(output, 'r').read().replace(REPLACER, strInput)
        fileOutPut = open(output, 'w')

        fileOutPut.write(strOutPut)
        fileOutPut.close()

        return True
    except:
      return False



if( replace(INPUT, OUTPUT) ):
    print('Ok')
else:
    print('Error')
