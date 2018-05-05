FUNC ?= UNDEFINED

default:

func:
	mkdir ${FUNC}
	cp Tpl/AWSExtentions.cs ${FUNC}/
	cp Tpl/AmUtil.cs ${FUNC}/
	cp Tpl/LambdaFunc.cs ${FUNC}/
	cp Tpl/Makefile ${FUNC}/
	cp Tpl/Program.cs ${FUNC}/
	cp Tpl/Tpl.csproj ${FUNC}/${FUNC}.csproj
	cp Tpl/README.md ${FUNC}/

all:
	${MAKE} func
	make -C ${FUNC} all
	make -C ${FUNC} deploy
