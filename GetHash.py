import hashlib

def exportHash(filePath):
    m=hashlib.md5()
    s1=hashlib.sha1()
    s256=hashlib.sha256()
    with open(filePath,'rb+') as f:
        b=f.read()
        m.update(b)
        s1.update(b)
        s256.update(b)
    print(filePath,":")
    print(m.name,":",m.hexdigest())
    print(s1.name,":",s1.hexdigest())
    print(s256.name,":",s256.hexdigest())

c=True
while c:
    path=input("enter file path or drag it in here:")
    exportHash(path)
    c=input("Is hashing another file?(y/n):")=='y'
