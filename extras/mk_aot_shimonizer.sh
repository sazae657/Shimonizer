#!/bin/bash
if [ "x" = "x${OUT}" ];then
	OUT=shimonizer.sh
fi
SRC_URL=https://raw.githubusercontent.com/sazae657/Shimonizer/master/Shimonizer/Shimonizer.cs
SRC=../Shimonizer/Shimonizer.cs
cat template/aot_heaer.txt >${OUT}
if [ "x-online" = "x$@" ];then
	curl ${SRC_URL} >.tmp.cs
else
	cat ${SRC}  >.tmp.cs
fi

mcs /t:exe  /out:.Shimonizer.exe /r:System.Xml.Linq .tmp.cs || exit

cat .Shimonizer.exe | gzip -9 | uuencode -m Shimonizer.exe >>${OUT}

cat template/aot_footer.txt >>${OUT}

chmod +x ${OUT}
#rm -f .Shimonizer.exe .tmp.cs

