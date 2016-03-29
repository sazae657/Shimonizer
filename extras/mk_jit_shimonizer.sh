#!/bin/sh
if [ "x" = "x${OUT}" ];then
	OUT=shimonizer.sh
fi
SRC_URL=https://raw.githubusercontent.com/sazae657/Shimonizer/master/Shimonizer/Shimonizer.cs
SRC=../Shimonizer/Shimonizer.cs
cat template/heaer.txt >${OUT}
if [ "x-online" = "x$@" ];then
	curl ${SRC_URL} | gzip -9 | uuencode -m Shimonizer.cs >>${OUT}
else
	cat ${SRC} | gzip -9 | uuencode -m Shimonizer.cs >>${OUT}
fi

cat template/footer.txt >>${OUT}
chmod +x ${OUT}

