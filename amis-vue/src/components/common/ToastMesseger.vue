<template>
    <div class="wp-notice-msg">
        <div :class="'icon_notice_' + statusAction"></div>
        <p v-if="statusAction == 'success'">{{ toastMsgContent }}</p>
        <p v-if="statusAction == 'error'">{{ toastMsgError[0] }}</p>
    </div>
</template>

<script>
export default {
    name: 'ToastMessenger',
    props: {
        toastMsgContent: String,
        statusAction: String,
        toastMsgError: Array
    }
}
</script>

<style scoped>
    .wp-notice-msg {
        position: absolute;
        top: 30px;
        left: 50%;
        transform: translateX(-50%);
        z-index: 9;
        background-color: #fff;
        padding: 5px 20px;
        font-size: 16px;
        font-family: 'Notosan-semibold';
        box-shadow: 0.5px 1px 15px #a5a5a5;
        visibility: hidden;
        display: flex;
        align-items: center;
    }
    .show-notice-msg{
        visibility: visible;
        -webkit-animation: fadein 0.5s, fadeout 0.5s 2.5s;
        animation: fadein 0.5s, fadeout 0.5s 2.5s;
    }

    @-webkit-keyframes fadein {
        from {top: 0; opacity: 0;} 
        to {top: 30px; opacity: 1;}
    }

    @keyframes fadein {
        from {top: 0; opacity: 0;}
        to {top: 30px; opacity: 1;}
    }

    @-webkit-keyframes fadeout {
        from {top: 30px; opacity: 1;} 
        to {top: 0; opacity: 0;}
    }

    @keyframes fadeout {
        from {top: 30px; opacity: 1;}
        to {top: 0; opacity: 0;}
    }

    .icon_notice_success{
        background: url('../../assets/content/img/Sprites.64af8f61.svg') no-repeat -288px -894px;
        width: 32px;
        height: 32px;
    }

    .icon_notice_error{
        background: url('../../assets/content/img/Sprites.64af8f61.svg') no-repeat -32px -962px;
        width: 32px;
        height: 32px;
    }

    .wp-notice-msg p{
        margin-left: 10px;
    }
</style>