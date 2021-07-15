#! /bin/bash

download_dir=download
script_fusing=sd_fusing_rpi3.sh

#tizen_version=""
#binary_type=${tizen_version}unified
#binary_prefix=tizen-${binary_type}

#tizen_download_url=http://10.113.136.26/snapshots/SR/Tizen-5.5/Tizen-5.5-Speaker/

default_tizen_version=latest
default_binary_version=latest
boot_img_name=iot-boot-arm64-rpi3
platform_img_name=iot-headless-2parts-armv7l-rpi3

print_wget_exit_status() {
	printf "wget returns error - "
	case "$1" in
	"1")
		echo "Generic error code"
		;;
	"2")
		echo "Parse error—for instance, when parsing command-line options, the ‘.wgetrc’ or ‘.netrc’..."
		;;
	"3")
		echo "File I/O error"
		;;
	"4")
		echo "Network failure"
		;;
	"5")
		echo "SSL verification failure"
		;;
	"6")
		echo "Username/password authentication failure"
		;;
	"7")
		echo "Protocol errors"
		;;
	"8")
		echo "Server issued an error response"
		;;
	*)
		echo "Unknow exit code - $1 "
		;;
	esac
}

download_fusing_script() {
	if [ ! -d $download_dir ]; then
		mkdir -p $download_dir
	fi

	if [ -e $download_dir/$script_fusing ]; then
		echo "Already downloaded [$script_fusing]"
	else
		wget https://git.tizen.org/cgit/platform/kernel/u-boot/plain/scripts/tizen/sd_fusing_rpi3.sh?h=tizen --output-document=$download_dir/$script_fusing
	fi
	ret=$?
	if ! [ "$ret" == 0 ]; then
		print_wget_exit_status $ret
		echo "[ERROR] fail to download [$script_fusing]"
		rm $download_dir/$script_fusing
		exit
	fi

	chmod 755 $download_dir/$script_fusing
}

fusing_sdcard() {
	download_fusing_script

	if command -v pv > /dev/null; then
		echo "Detected pv..."
	else
		echo "Installing pv..."
		sudo apt-get install -q -y pv
	fi

	sudo $download_dir/$script_fusing -d $usb_node --format
	sudo $download_dir/$script_fusing -d $usb_node -b $1
	sudo $download_dir/$script_fusing -d $usb_node -b $2
}

receive_device_nodes() {
	local _node_result=$1
	local node_list=`lsblk -o NAME,RM,TYPE,MODEL | grep 'disk' | grep -w '1' --color=never`
	local node_num=`echo "${node_list}" | wc -l`
	local node_default=`echo ${node_list} | awk '{print $1}'`

	if [ "$node_list" = "" ]; then
		echo "You have no removable storage now, check it and try again"
		echo "Bye Bye ~"
		exit 1
	fi

	echo
	echo "######################################################"
	echo "You have ${node_num} Removable Storage Device(s) as follows"
	echo "${node_list}"
	echo "######################################################"
	echo
	echo " ** Warning **  Be Careful to select device node, All existing data in that storage will be lost."
	echo
	echo "Please type device node of usb [press enter key to use default(${node_default})] : "
	read input_node
	if [ "$input_node" = "" ]; then
		eval $_node_result=/dev/${node_default}
	else
		if [ "$input_node" = "sda" ]; then
			echo "[Warning] 'sda' is normally main storage"
			echo "          If you REALLY want use 'sda' type it again or type other one"
			read input_node
		fi
		eval $_node_result=/dev/${input_node}
	fi
}

display_help() {
	echo "Usage: $0 -b [boot image file] -p [platform image file]"
	echo
	exit 1
}

main() {

	if [ -z "$BOOT_IMG" ]; then
		echo "Boot image file is not selected"
		display_help
		exit 1
	fi

	if [ -z "$PLATFORM_IMG" ]; then
		echo "Platform image file is not selected"
		display_help
		exit 1
	fi

	if [ ! -e $BOOT_IMG ]; then
		echo "Boot image file[$BOOT_IMG] does not exist"
		exit 1
	else
		echo
		echo "Boot image file is [${BOOT_IMG##*/}]"
	fi

	if [ ! -e $PLATFORM_IMG ]; then
		echo "platform image file[$PLATFORM_IMG] does not exist"
		exit 1
	else
		echo "Platform image file is [${PLATFORM_IMG##*/}]"
	fi

	receive_device_nodes usb_node
	echo "###########  use dev node : ${usb_node}"
	if [ ! -b ${usb_node} ]; then
		echo "[ERROR] Selected storage[${usb_node}] does not exist"
		exit 1
	fi

	sleep 1
	fusing_sdcard ${BOOT_IMG} ${PLATFORM_IMG}

	echo "######################################################"
	echo "DONE"
	echo "######################################################"
}

############ Start Here
#set -x

while [[ $# -gt 0 ]]
do
key="$1"

case $key in
	-b)
	BOOT_IMG="$2"
	shift
	shift
	;;
	-p)
	PLATFORM_IMG="$2"
	shift
	shift
	;;
	*)
	shift
	;;
esac
done

if [ "${1}" != "--source-only" ]; then
	main "${@}"
fi