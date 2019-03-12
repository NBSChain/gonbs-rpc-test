SHELL=PATH='$(PATH)' /bin/sh

PLATFORM := $(shell uname -o)

EXTEND := .exe
ifeq ($(PLATFORM), Msys)
    INCLUDE := ${shell echo "$(GOPATH)"|sed -e 's/\\/\//g'}
else ifeq ($(PLATFORM), Cygwin)
    INCLUDE := ${shell echo "$(GOPATH)"|sed -e 's/\\/\//g'}
else
	INCLUDE := $(GOPATH)
	EXTEND	:=
endif

EXENAME := nbsgrpc2-lib$(EXTEND)