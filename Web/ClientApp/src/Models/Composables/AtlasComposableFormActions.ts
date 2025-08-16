import { router, useForm } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import { computed, ref } from "vue";
import { string } from "yup";

const { opts } = useAtlasComposableLoadingCallbacks();

export const useAtlasComposableFormActions = () => {
  const _formValues = ref<any>({});
  const _props = ref<any>({});
  const _formConfs = ref<{url:string, resource: string}>()



  const isSaveEnabled = computed(() => {
    if(_formConfs.value?.url.includes("update")){
      if (_props.value.extras) {
        if (!_props.value.extras.editable) return false;
  
        if (_props.value.extras.editable) return true;
      }
    }


    if( !_formValues.value.isValid ) return false

    if( _formValues.value?.isValid ) return true
  });

  const pickedColor = computed( () => {
    if(_formValues?.value?.data?.color)
      return _formValues.value.data.color

    return '#00000'
  })

  const cancelForm = () => {
    router.get(`/admin/${_formConfs.value?.resource}/index`, {}, opts);
  };

  const submitForm = () => {
    opts.onStart({});
    const f = { ..._formValues.value.data };

    const form = useForm(f);

    form.post(_formConfs.value?.url, {
      _method: "post",
      forceFormData: true,
      opts,
    });
  };

  const setFormValues = (formValues: any) => {
    console.log('ssssetitng', formValues)
    if(formValues?.isValid){
      _formValues.value = formValues;
      return 
    }
    
    if(_formConfs.value?.url.includes("update") && formValues.values?.data){
      _formValues.value = {data:null, isValid:true}
      return
    }
    
    _formValues.value = formValues
  };

  const setProps = (props: any) => {
    _props.value = props;
  };

  const setFormPaths = (resource: string, isAdmin = true) =>{
    
    const hasId = _props.value.mainResource?.id;

    const confs = {resource, url: ''}
    if(isAdmin)
      if(!!hasId)
        confs.url = `/admin/${resource}/update/${hasId}`
      else
        confs.url = `/admin/${resource}/store`

    else
      if(!!hasId)
        confs.url = `/store/${resource}/update/${hasId}`
      else
        confs.url = `/store/${resource}/store`

    _formConfs.value = confs
      
  }

  return {

    isSaveEnabled,

    pickedColor,

    
    setFormPaths,
    setFormValues,
    cancelForm,
    submitForm,
    setProps,
  };
};
