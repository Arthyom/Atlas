import { router, useForm } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import { computed, ref } from "vue";
import { string } from "yup";

const { opts } = useAtlasComposableLoadingCallbacks();

export const useAtlasComposableCustomFormActions = ( resource: string, isAdmin = true, formValues: any = null, initialValues: any = null) => {
  const _formValues = ref( formValues )
  const _props = ref(initialValues);
  const _formConfs = computed( ()=> {  
    
    const hasId = _props.value?.mainResource?.id;

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

      return confs;

    })



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

  // const pickedColor = computed( () => {
  //   if(_formValues?.value?.data?.color)
  //     return _formValues.value.data.color

  //   return '#00000'
  // })

  const cancelCustomForm = () => {
    router.get(`/admin/${_formConfs.value?.resource}/index`, {}, opts);
  };

  const submitCustomForm = () => {
    opts.onStart({});
    const f = { ..._formValues.value.data };

    const form = useForm(f);

    form.post(_formConfs.value?.url, {
      _method: "post",
      forceFormData: true,
      opts,
    });
  };

  const submitCustomFormWithData = (data:any) => {
    opts.onStart({});
    const f = { ...data};

    const form = useForm(f);

    form.post(_formConfs.value?.url, {
      _method: "post",
      forceFormData: true,
      opts,
    });
  };

  const setCustomFormValues = (formValues: any) => {
    _formValues.value = formValues
  };

  
  return {

    isSaveEnabled,


    
    cancelCustomForm,
    submitCustomForm,
    submitCustomFormWithData,
    setCustomFormValues
    
  };
};
