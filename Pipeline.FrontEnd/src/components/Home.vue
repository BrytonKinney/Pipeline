<template>
    <div class="home">
        <Administration></Administration>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Administration from './components/Administration.vue';

    @Component({
        components: {
            Administration
        },
        props: {
            msg: {
                type: String
            }
        }
    })
    export default class Home extends Vue {}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    #home {

    }
</style>
